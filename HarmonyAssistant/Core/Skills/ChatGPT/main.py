import freeGPT
from asyncio import run


async def main():
    while True:
        prompt = input("👦: ")
        try:
            resp = await getattr(freeGPT, "gpt3").Completion().create(prompt)
            print(f"🤖: {resp}")
        except Exception as e:
            print(f"🤖: {e}")
run(main())