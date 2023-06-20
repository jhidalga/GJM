﻿namespace GJM.Services
{
    public class EventService
    {
        public event Action OnPostUpdated;
        public event Action OnPostDeleted;
        public event Action OnGameReserve;

        public void PostUpdated()
        {
            OnPostUpdated?.Invoke();
        }

        public void PostDeleted() 
        {
            OnPostDeleted?.Invoke();
        }

        public void ReserveGame() 
        {
            OnGameReserve?.Invoke();
        }
    }

}
