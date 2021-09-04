using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace __UI_____Panda_A_.Core.User_Level
{
	public class Animations
	{
		Storyboard StoryBoard = new Storyboard();
		TimeSpan duration = TimeSpan.FromMilliseconds(500);
		TimeSpan duration2 = TimeSpan.FromMilliseconds(1000);

        private IEasingFunction Smooth
        {
            get;
            set;
        }
        = new QuarticEase
        {
        EasingMode = EasingMode.EaseInOut
        };

        public async void FadeOut(DependencyObject Object)
        {
            DoubleAnimation Fade = new DoubleAnimation()
            {
                From = 1.0,
                To = 0.0,
                Duration = new Duration(duration),
            };
            Storyboard.SetTarget(Fade, Object);
            Storyboard.SetTargetProperty(Fade, new PropertyPath("Opacity", 1));
            StoryBoard.Children.Add(Fade);
            StoryBoard.Begin();
            await Task.Delay(500);
            StoryBoard.Children.Remove(Fade);
        }

        public async void Fade(DependencyObject Object)
        {
            DoubleAnimation FadeIn = new DoubleAnimation()
            {
                From = 0.0,
                To = 1.0,
                Duration = new Duration(duration),
            };
            Storyboard.SetTarget(FadeIn, Object);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath("Opacity", 1));
            StoryBoard.Children.Add(FadeIn);
            StoryBoard.Begin();
            await Task.Delay(500);
            StoryBoard.Children.Remove(FadeIn);
        }

        //public async void ObjectShift(DependencyObject Object, Thickness Get, Thickness Set)
        //{
        //    ThicknessAnimation Animation = new ThicknessAnimation()
        //    {
        //        From = Get,
        //        To = Set,
        //        Duration = duration2,
        //        EasingFunction = Smooth,
        //    };
        //    Storyboard.SetTarget(Animation, Object);
        //    Storyboard.SetTargetProperty(Animation, new PropertyPath(MarginProperty));
        //    StoryBoard.Children.Add(Animation);
        //    StoryBoard.Begin();
        //    await Task.Delay(1000);
        //    StoryBoard.Children.Remove(Animation);
        //}
    }
}
