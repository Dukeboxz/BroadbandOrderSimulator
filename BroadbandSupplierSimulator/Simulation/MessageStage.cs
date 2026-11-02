using BroadbandSupplierSimulator.Data.Entities;

namespace BroadbandSupplierSimulator.Simulation;

public class MessageStage
{
    public int SequenceOrder { get; set; }

    public ProductOrderItemState State { get; set; }

    public MessageSubStatus? SubStatus { get; set; }
}
