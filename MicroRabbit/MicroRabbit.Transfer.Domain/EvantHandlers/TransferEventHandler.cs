using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Domain.EvantHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _transferRepositoory;

        public TransferEventHandler(ITransferRepository transferRepositoory)
        {
            _transferRepositoory = transferRepositoory;
        }
        public Task Handler(TransferCreatedEvent @event)
        {
            _transferRepositoory.Add(new TransferLog
            {
                FromAccount = @event.From,
                ToAccount = @event.To,
                TransferAmount = @event.Amaunt
            });
            return Task.CompletedTask;
        }
    }
}
