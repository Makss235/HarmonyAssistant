import sounddevice as sd
import vosk
import queue
import json

q = queue.Queue()
model = vosk.Model('vosk-model-small-ru')
fn_sr_result = "STTF.txt"

device = sd.default.device
samplerate = int(sd.query_devices(device[0], 'input')['default_samplerate'])


def callback(indata, frames, time, status):
    q.put(bytes(indata))


def main():
    with sd.RawInputStream(samplerate=samplerate, blocksize=16000, device=device[0], dtype='int16',
                           channels=1, callback=callback):
        rec = vosk.KaldiRecognizer(model, samplerate)
        while True:
            data = q.get()
            if rec.AcceptWaveform(data):
                result = json.loads(rec.Result())['text']
                with open(fn_sr_result, 'w', encoding='utf-8') as sr_res:
                    sr_res.write(result)
                # print(result)


if __name__ == '__main__':
    main()
