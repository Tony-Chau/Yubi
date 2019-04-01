import speech_recognition as sr
import pyaudio

def SpeechToText(sec=5):
    r = sr.Recognizer()
    with sr.Microphone() as source:
        audio = r.listen(source)
    try:
        return r.recognize_google(audio)
    except:
        return ""
