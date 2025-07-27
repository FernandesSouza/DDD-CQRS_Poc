using DomainDrivenDesign_Poc.Business.Domain.DomainEvents;
using DomainDrivenDesign_Poc.Business.Domain.DomainEvents.Base;
using DomainDrivenDesign_Poc.Business.Domain.Entities.Base;
using DomainDrivenDesign_Poc.Business.Domain.EntitiesValidation;
using DomainDrivenDesign_Poc.Business.Domain.Enums;
using DomainDrivenDesign_Poc.Business.Domain.ValueObjects;

namespace DomainDrivenDesign_Poc.Business.Domain.Entities;

public sealed class Student : Entity
{
    //ORM
    protected Student()
    {
    }

    public Student(
        string fullName,
        Email email,
        Document document)
    {
        FullName = fullName;
        Email = email;
        Document = document;

        EntityValidation(this, new StudentValidation());
    }

    private void AddSubscription(Subscription subscription)
    {
        Subscription = subscription;
    }

    public void CreateSubscriptionWithPayment(
        ETypeSubscription typeSubscription,
        string paymentNumber,
        decimal paymentTotal,
        decimal paymentTotalPaid,
        string paymentPayer)
    {
        var subscription = new Subscription(
            expireDate: DateTime.Now.AddMonths(1),
            typeSubscription: typeSubscription,
            createDate: DateTime.Now);

        subscription.LinkedToStudent(Id);
        subscription.Active();

        var payment = new Payment(
            number: paymentNumber,
            paidDate: DateTime.Now,
            expireDate: DateTime.Now.AddDays(3),
            total: paymentTotal,
            totalPaid: paymentTotalPaid,
            payer: paymentPayer,
            Document,
            Email);

        payment.LinkedToSubscription(subscription.Id);
        subscription.AddPayments(payment);
        AddSubscription(subscription);

        SendEmail(FullName, Email);
    }

    private void SendEmail(string fullname, Email email)
    {
        DomainEvent<StudentRegisterEvent>.Handler(new StudentRegisterEvent(fullname, email));
    }

    public string FullName { get; init; }
    public Email Email { get; init; }
    public Document Document { get; init; }
    public Subscription? Subscription { get; set; }
}