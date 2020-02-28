using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.EventAggregator
{
    //Одна из самых простых реализаций паттерна EventAggregator
    //Используется статический Generic event, на который будут подписываться нужные классы и объекты
    public class EventAggregator
    {
        public static void Post<T>(object sender, T eventHandler)
        {
            EventAggregatorInner<T>.Post(sender, eventHandler);
        }

        //подписка на нужное событие, где T - это класс события с параметрами
        //Если параметров в событии нет - создаём просто пустой класс события
        public static void Subscribe<T>(Action<object, T> action)
        {
            EventAggregatorInner<T>.Event += action;
        }

        //отписываемся от события. Важно, все объекты, которые рождаются и уничтожаються в runtime
        //необходимо обязательно выполнять отписку!
        public static void Unsubscribe<T>(Action<object, T> action)
        {
            EventAggregatorInner<T>.Event -= action;
        }

        //Вспомогательный статический Generic класс для хранения нужного для нас события
        private static class EventAggregatorInner<T>
        {
            public static Action<object, T> Event;

            public static void Post(object sender, T eventHandler)
            {
                Event?.Invoke(sender, eventHandler);
            }
        }
    }
}
