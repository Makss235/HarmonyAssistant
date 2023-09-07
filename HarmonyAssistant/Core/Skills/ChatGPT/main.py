import freeGPT
import os
from asyncio import run

async def main():
    with open("IGPTF.txt", 'r', encoding="utf-8") as file:
        line = file.read()

    prompt = line
    with open("OGPTF.txt", 'w', encoding="utf-8") as file:
        try:
            resp = await getattr(freeGPT, "gpt3").Completion().create(prompt)
            file.write(resp)
        except Exception as e:
            file.write("Error")
run(main())