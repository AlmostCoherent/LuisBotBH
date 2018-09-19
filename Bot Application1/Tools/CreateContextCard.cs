using Microsoft.Bot.Connector;
using System.Collections.Generic;

namespace Bot_Application1
{
    public static class CreateContextCard
    {
        public static Attachment GetHeroCard(string title, string subTitle = null, string text = null, List<CardImage> cardImages = null, List<CardAction> cardButtons = null)
        {
            var heroCard = new HeroCard
            {
                Title = title,
                Subtitle = subTitle,
                Text = text,
                Images = cardImages,
                Buttons = cardButtons
            };
            return heroCard.ToAttachment();
        }
        public static Attachment GetThumbnailCard(string title, string subtitle= null, string text = null, CardImage cardImage = null, CardAction cardAction = null)
        {
            var heroCard = new ThumbnailCard
            {
                Title = title,
                Subtitle = subtitle,
                Text = text,
                Images = new List<CardImage>() { cardImage },
                Buttons = new List<CardAction>() { cardAction },
            };

            return heroCard.ToAttachment();
        }

        public static Attachment GetAnimationCard(string title = null, string subtitle = null, string text = null, ThumbnailUrl animationUrl = null, List<MediaUrl> mediaUrl = null, bool autoLoop = false, bool autoStart = true)
        {
            var animationCard = new AnimationCard
            {
                Title = title,
                Subtitle = subtitle,
                Media = mediaUrl,
                Autoloop = autoLoop,
                Autostart = autoStart,
                
            };
            return animationCard.ToAttachment();
        }

    }
}