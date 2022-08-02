namespace PureMVC.Patterns
{
    using Assets.PureMVC.Interfaces;
    using PureMVC.Interfaces;
    using System;

    public class SimpleCommand : Notifier, ICommand, INotifier
    {
        public virtual void Execute(INotification notification)
        {
        }
    }
}

