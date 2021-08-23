using System.Media;

namespace ttManager
{
    static class FormsHelper
    {
        internal static void PlaySound(SoundTypes st)
        {
            switch (st)
            {
                case SoundTypes.Applause:

                    SoundPlayer player = new SoundPlayer("Applause.wav");
                    player.Play();
                    break;
            }
        }
    }
}
