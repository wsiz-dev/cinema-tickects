using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.Domain.Service.DTO;

namespace CinemaTickets.Domain.Service
{
    public interface IEmailService
    {
        void SendPurchaseNotification(PurchaseNotificationDto purchaseNotification);
    }
}
