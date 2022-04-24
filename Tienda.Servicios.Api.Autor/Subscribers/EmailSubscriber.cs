using Tienda.Servicios.RabbitMQ.Bus.BusRabbit;
using Tienda.Servicios.RabbitMQ.Bus.EventQueue;

namespace Tienda.Servicios.Api.Autor.Subscribers
{
    public class EmailSubscriber : IEventManager<EmailEventQueue>
    {
        public EmailSubscriber()
        {

        }

        public Task Handler(EmailEventQueue @event)
        {
            
            //you logic here!


            return Task.CompletedTask;
        }
    }
}
