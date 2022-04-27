import requests
import re

homePage = open("./Jhin_LoL_Audio.htm", "r", encoding="utf-8")
audioSources = []
for line in homePage.readlines():
    if(line.find(".ogg") != -1):
        start = line.find("https://static.wikia.nocookie.net")
        end = line.find("\"", start)
        audioSources.append(line[start:end])
for source in audioSources:
    filenameMatch = re.search("[^/]*\.ogg", source)
    if(filenameMatch is not None):
        print("Fetching:", filenameMatch.group())
        with open("C:/Users/Keaton/source/repos/JhinFour/JhinFour/" + filenameMatch.group(), "wb") as fp:
            audioFile = requests.get(source)
            fp.write(audioFile.content)
            print("File written to", fp.name)


    

