import sounddevice
import vosk
import json
import queue

q = queue.Queue()

model = vosk.Model('model-small-ru')
device = sounddevice.default.device
samplerate = int(sounddevice.query_devices(device[0], 'input')['default_samplerate'])

def callback(indata, frames, time, status):

    q.put(bytes(indata))


with sounddevice.RawInputStream(samplerate=samplerate, blocksize = 16000, device=device[0], dtype='int16',
                                channels=1, callback=callback):

    rec = vosk.KaldiRecognizer(model, samplerate)
    while True:
        data = q.get()
        if rec.AcceptWaveform(data):
            print(json.loads(rec.Result())['text'])
        # else:
        #     print(rec.PartialResult())