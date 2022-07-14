using System;

namespace Homework
{
    public interface IStars
    {
        int StarsValue { get; set; }
        event Action<int> OnStarsChanged;
    }
}