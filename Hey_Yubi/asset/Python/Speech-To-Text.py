import speech_recognition as sr
import pyaudio
from threading import Thread, Event
import time

stop_event = Event()
word = ""
def speechaction():
    r = sr.Recognizer()
    with sr.Microphone() as source:
        audio = r.listen(source)
    try:
        word = r.recognize_google(audio)
    except:
        word = ""

def SpeechToText(sec=5):
    action_thread = Thread(target=speechaction)
    action_thread.start()
    action_thread.join(timeout=sec)

    stop_event.set()
    return word
