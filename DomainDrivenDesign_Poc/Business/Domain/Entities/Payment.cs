using DomainDrivenDesign_Poc.Business.Domain.Entities.Base;
using DomainDrivenDesign_Poc.Business.Domain.ValueObjects;

namespace DomainDrivenDesign_Poc.Business.Domain.Entities;

public sealed class Payment : Entity
{
    //ORM
    protected Payment()
    {
    }

    public Payment(
        string number,
        DateTime paidDate,
        DateTime expireDate,
        decimal total,
        decimal totalPaid,
        string payer,
        Document document,
        Email email)
    {
        Number = number;
        PaidDate = paidDate;
        ExpireDate = expireDate;
        Total = total;
        TotalPaid = totalPaid;
        Payer = payer;
        Document = document;
        Email = email;
    }
    
    public void LinkedToSubscription(Guid subscriptionId)
    {
        SubscriptionId = subscriptionId;
    }

    public string Number { get; set; }
    public DateTime PaidDate { get; private set; }
    public DateTime ExpireDate { get; private set; }
    public decimal Total { get; private set; }
    public decimal TotalPaid { get; private set; }
    public string Payer { get; set; }
    public Document Document { get; set; }
    public Email Email { get; set; }
    public Guid SubscriptionId { get; set; }
    public Subscription? Subscription { get; set; }
}