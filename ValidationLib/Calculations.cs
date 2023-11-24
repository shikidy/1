using System.Collections.Generic;
using System;

namespace SF2022UserNNLib
{
    public class Calculations
    {
        public string[] AvailablePeriods(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
        {
            
            if (consultationTime <= 0)
            {
                throw new ArgumentException("Длительность консультации должна быть больше нуля.");
            }

            
            if (beginWorkingTime >= endWorkingTime)
            {
                throw new ArgumentException("Время начала рабочего дня должно быть раньше времени окончания рабочего дня.");
            }

            
            for (int i = 0; i < startTimes.Length; i++)
            {
                if (startTimes[i] < beginWorkingTime || startTimes[i] > endWorkingTime)
                {
                    throw new ArgumentException("Обнаружено недопустимое время начала.");
                }

                if (durations[i] <= 0)
                {
                    throw new ArgumentException("Обнаружена недопустимая продолжительность.");
                }
            }

            List<(TimeSpan, TimeSpan)> blockedPeriods = new List<(TimeSpan, TimeSpan)>();
            for (int i = 0; i < startTimes.Length; i++)
            {
                TimeSpan start = startTimes[i];
                TimeSpan end = start.Add(TimeSpan.FromMinutes(durations[i]));
                blockedPeriods.Add((start, end));
            }

            TimeSpan workingTimeStart = beginWorkingTime;
            TimeSpan workingTimeEnd = endWorkingTime;
            TimeSpan consultationTimeSpan = TimeSpan.FromMinutes(consultationTime);

            List<string> freePeriods = new List<string>();
            TimeSpan currentTime = workingTimeStart;

            while (currentTime + consultationTimeSpan <= workingTimeEnd)
            {
                bool isCollided = false;
                foreach ((TimeSpan start, TimeSpan end) in blockedPeriods)
                {
                    if ((start <= currentTime && currentTime < end) || (start < currentTime + consultationTimeSpan && currentTime + consultationTimeSpan <= end))
                    {
                        isCollided = true;
                        currentTime = end;
                        break;
                    }
                }

                if (!isCollided)
                {
                    freePeriods.Add($"{currentTime:hh\\:mm}-{(currentTime + consultationTimeSpan):hh\\:mm}");
                    currentTime += consultationTimeSpan;
                }
            }

            return freePeriods.ToArray();
        }
    }
}
