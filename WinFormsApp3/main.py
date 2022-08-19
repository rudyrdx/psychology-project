import speech_recognition as sr
from os import listdir, path
import sys
import pandas as pd
"""
KEEP THIS PYTHON FILE WITH THE EXE
KEEP THIS PYTHON FILE WITH THE EXE
KEEP THIS PYTHON FILE WITH THE EXE
"""
cmd = sys.argv[1]
# audioPath = "C:\\Users\\Rudyrdx\\Desktop\\Psychology Test\\"+cmd+"\\Audio"
#get desktop path
desktop = path.join(path.join(path.expanduser('~')), 'Desktop')
audioPath = path.join(desktop, "Psychology Test\\"+cmd+"\\Audio\\")
csvPath = path.join(desktop, "Psychology Test\\"+cmd+"\\")

def transcribe(AUDIO_FILE):
        # use the audio file as the audio source                                        
        r = sr.Recognizer()
        with sr.AudioFile(AUDIO_FILE) as source:
                audio = r.record(source)  # read the entire audio file 
                try:
                        return r.recognize_google(audio)
                except sr.UnknownValueError:
                        return "NANI?"

output = []
fileList = listdir(audioPath)
#for each file in the directory transcribe it
for file in fileList:
        AUDIO_FILE = audioPath+file
        result = transcribe(AUDIO_FILE)
        # #tokenize the result
        # result = result.split()
        # #add the result to the output list
        output.append(result)

#create a dataframe with the output
df = pd.DataFrame(output)
df.index += 1
df.to_csv(csvPath+"Result_"+cmd+".csv", index=True,header=False)