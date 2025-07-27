using DomainDrivenDesign_Poc.Business.Domain.DomainEvents;
using DomainDrivenDesign_Poc.Business.Domain.DomainEvents.Base;
using DomainDrivenDesign_Poc.Business.Domain.Entities;
using DomainDrivenDesign_Poc.Business.Domain.Enums;
using DomainDrivenDesign_Poc.Business.Domain.ValueObjects;

namespace DomainDrivenDesign_UnitTest.Domain;

public sealed class StudentDomainTest
{
    [Fact]
    [Trait("Domain", "Student - Success")]
    public void Create_Student_Success()
    {
        const string name = "João";
        var email = new Email("joao@email.com");
        var document = new Document("12345678901");

        var student = new Student(name, email, document);

        Assert.NotNull(student);
        Assert.Equal(name, student.FullName);
        Assert.Equal(email, student.Email);
        Assert.Equal(document, student.Document);
    }

    [Fact]
    [Trait("Domain", "Student - Fail(invalid name)")]
    public void Create_Student_Fail_InvalidName()
    {
        const string name = "J";
        var email = new Email("joao@email.com");
        var document = new Document("12345678901");

        var student = new Student(name, email, document);

        Assert.False(student.IsValid);
    }

    [Fact]
    [Trait("Domain", "Student - Fail(invalid document)")]
    public void Create_Student_Fail_InvalidDocument()
    {
        const string name = "João";
        var email = new Email("joao@email.com");
        var document = new Document("da");

        var student = new Student(name, email, document);

        Assert.False(student.IsValid);
    }

    private bool _eventRes;

    [Fact]
    [Trait("Domain", "Service Domain - Create Subscription with payment(Success)")]
    public void CreateStudent_WithDomainService_ReturnSuccess()
    {
        DomainEvent<StudentRegisterEvent>.OnEventDomain += OnEventDomain;
        var student = new Student(
            "João",
            new Email("joao@email.com"),
            new Document("12345678901"));

        student.CreateSubscriptionWithPayment(
            ETypeSubscription.Monthly,
            "1234 1234 1234 1234",
            420.54m,
            420.54m,
            "João");

        Assert.NotNull(student.Subscription);
        Assert.NotNull(student.Subscription.Payments);
        Assert.True(_eventRes);
    }

    private void OnEventDomain(StudentRegisterEvent? domainEvent)
    {
        _eventRes = domainEvent is not null;
    }
}