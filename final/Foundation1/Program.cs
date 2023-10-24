// Interface for MediaPlayer
interface MediaPlayer
{
    void Play();
    void Pause();
    void Stop();
}

// Class representing a generic media file
class MediaFile
{
    public string FileName { get; }

    public MediaFile(string fileName)
    {
        FileName = fileName;
    }
}

// AudioPlayer class implementing the MediaPlayer interface
class AudioPlayer : MediaPlayer
{
    private MediaFile currentMedia;

    public void SetMedia(MediaFile media)
    {
        currentMedia = media;
    }

    public void Play()
    {
        Console.WriteLine($"Playing audio file: {currentMedia.FileName}");
        // Implementation specific to playing audio
    }

    public void Pause()
    {
        Console.WriteLine("Pausing audio playback");
        // Implementation specific to pausing audio
    }

    public void Stop()
    {
        Console.WriteLine("Stopping audio playback");
        // Implementation specific to stopping audio
    }
}

// VideoPlayer class implementing the MediaPlayer interface
class VideoPlayer : MediaPlayer
{
    private MediaFile currentMedia;

    public void SetMedia(MediaFile media)
    {
        currentMedia = media;
    }

    public void Play()
    {
        Console.WriteLine($"Playing video file: {currentMedia.FileName}");
        // Implementation specific to playing video
    }

    public void Pause()
    {
        Console.WriteLine("Pausing video playback");
        // Implementation specific to pausing video
    }

    public void Stop()
    {
        Console.WriteLine("Stopping video playback");
        // Implementation specific to stopping video
    }
}

// Main program to demonstrate the usage
class Program
{
    static void Main()
    {
        // Create instances of media players
        AudioPlayer audioPlayer = new AudioPlayer();
        VideoPlayer videoPlayer = new VideoPlayer();

        // Create instances of media files
        MediaFile audioFile = new MediaFile("sample_audio.mp3");
        MediaFile videoFile = new MediaFile("sample_video.mp4");

        // Set media for players
        audioPlayer.SetMedia(audioFile);
        videoPlayer.SetMedia(videoFile);

        // Play, pause, and stop audio
        audioPlayer.Play();
        audioPlayer.Pause();
        audioPlayer.Stop();

        // Play, pause, and stop video
        videoPlayer.Play();
        videoPlayer.Pause();
        videoPlayer.Stop();
    }
}
