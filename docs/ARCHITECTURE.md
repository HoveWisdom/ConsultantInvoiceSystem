# System Architecture — Consultant Invoice & Notification System

---

## Overview

This system automates consultant invoice workflows using a set of microservices based on Azure Functions, Azure Durable Functions, Service Bus, and SQL Server.
It leverages event-driven architecture, CQRS, and SOLID design principles for scalability and maintainability.

---

## Microservices Architecture

```mermaid
flowchart LR
    N(NotificationService)
    I(InvoiceService)
    A(ApprovalService)
    P(PaymentService)
    S[(Azure Service Bus)]
    DB[(SQL Server)]

    N -- Reminder API/Events --> I
    I -- InvoiceSubmitted Event --> S
    S -- > A
    A -- ApprovalCompleted Event --> S
    S -- > P
    I -- Store Invoice --> DB
    A -- Store Approval --> DB
    P -- Update Payment --> DB
    N -- Notifications --> Consultants
```

---

## High-Level Workflow

```mermaid
sequenceDiagram
    participant Consultant
    participant NotificationService
    participant InvoiceService
    participant ServiceBus
    participant ApprovalService
    participant PaymentService

    NotificationService->>Consultant: Send monthly reminder
    Consultant->>InvoiceService: Submit invoice (HTTP API)
    InvoiceService->>SQL: Store invoice
    InvoiceService->>ServiceBus: Publish InvoiceSubmitted event
    ApprovalService->>ServiceBus: Consume InvoiceSubmitted event
    ApprovalService->>SQL: Persist approval status
    ApprovalService->>ServiceBus: Publish ApprovalCompleted event
    PaymentService->>ServiceBus: Consume ApprovalCompleted event
    PaymentService->>SQL: Update invoice/payment status
    PaymentService->>NotificationService: Trigger payment notification (optional)
```

---

## Entity Relationship Diagram (ERD)

```mermaid
erDiagram
    Consultant {
      Guid ConsultantId PK
      string Name
      string Email
    }
    Invoice {
      Guid InvoiceId PK
      Guid ConsultantId FK
      decimal Amount
      datetime SubmittedAt
      string Status
    }
    Approval {
      Guid ApprovalId PK
      Guid InvoiceId FK
      string Approver
      string Status
      datetime DecisionDate
    }
    Payment {
      Guid PaymentId PK
      Guid InvoiceId FK
      decimal Amount
      string Status
      datetime PaidAt
    }
    Consultant ||--o{ Invoice : submits
    Invoice ||--o{ Approval : triggers
    Invoice ||--o{ Payment : paid_via
```

---

## Patterns Used

- **Microservices & Event-Driven Architecture:** Services communicate via Service Bus events.
- **CQRS:** Separate API endpoints and data flows for commands and queries.
- **SOLID Principles:** Single Responsibility, Dependency Injection, maintainable code structure.
- **Durable Functions:** State and orchestration for approval workflow.
- **Repository Pattern:** Database interaction is abstracted for maintainability.
- **CI/CD:** Samples via GitHub Actions (see `.github/workflows/`).

---

## Technologies

| Component           | Tech Stack              |
|---------------------|------------------------|
| Compute             | Azure Function Apps    |
| Orchestration       | Azure Durable Functions|
| Messaging           | Azure Service Bus      |
| Persistence         | SQL Server, EF Core    |
| Diagrams            | Mermaid (Markdown)     |
| CI/CD               | GitHub Actions         |

---

## Further Documentation

- Feature details: See each microservice
- Examples: See README, sample requests
- Contribute: Fork, PR, raise an issue