using Microsoft.Skype.Bots.Media;

public class EchoAudioSendHandler : IAudioSendHandler
{
    private byte[] _buffer;
    private int _position;

    public EchoAudioSendHandler(byte[] audioBuffer)
    {
        _buffer = audioBuffer;
        _position = 0;
    }

    public int GetFormat(out AudioFormat format)
    {
        format = AudioFormat.Pcm16K;
        return 0;
    }

    public void Send(AudioSendBuffer sendBuffer)
    {
        int count = Math.Min(sendBuffer.Buffer.Length, _buffer.Length - _position);
        if (count > 0)
        {
            Buffer.BlockCopy(_buffer, _position, sendBuffer.Buffer, 0, count);
            sendBuffer.Length = count;
            _position += count;
        }
        else
        {
            sendBuffer.Length = 0;
        }
    }

    public void Dispose() { }
}
