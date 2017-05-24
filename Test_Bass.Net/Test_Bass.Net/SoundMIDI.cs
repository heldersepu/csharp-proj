using System;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Midi;

namespace Test_Bass.Net
{
    class SoundMIDI
    {
        public static void Play()
        {
            BASS_MIDI_EVENT[] events = {
                new BASS_MIDI_EVENT(BASSMIDIEvent.MIDI_EVENT_TEMPO, 500000, 0, 0,0),
                new BASS_MIDI_EVENT(BASSMIDIEvent.MIDI_EVENT_PROGRAM, 40, 0, 0,0),
                new BASS_MIDI_EVENT(BASSMIDIEvent.MIDI_EVENT_NOTE, MAKEWORD(60,100), 0, 0 ,0),
                //new BASS_MIDI_EVENT(BASSMIDIEvent.MIDI_EVENT_NOTE, MAKEWORD(80,100), 0, 0 ,0),
                new BASS_MIDI_EVENT(BASSMIDIEvent.MIDI_EVENT_NOTE, 60, 0, 200,0 ),
                //new BASS_MIDI_EVENT(BASSMIDIEvent.MIDI_EVENT_NOTE, 80, 0, 96,0 ),
                new BASS_MIDI_EVENT(BASSMIDIEvent.MIDI_EVENT_END, 0, 0, 2000,0),
            };

            int stream = BassMidi.BASS_MIDI_StreamCreateEvents(events, 100, BASSFlag.BASS_SAMPLE_LOOP, 1);

            Bass.BASS_ChannelPlay(stream, true);

            Console.ReadKey(false);
            Bass.BASS_StreamFree(stream);
        }

        public static int MAKEWORD(byte a, byte b)
        {
            return (ushort)(a | (b << 8));
        }
    }
}
