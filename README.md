# Consultant Invoice & Notification System

_Automates invoice submission, approval, payment, and notifications for consultants using Azure Functions, Durable Functions, Azure Service Bus, and SQL Server._

---

## Project Structure

```
ConsultantInvoiceSystem/
├── NotificationService/   # Sends reminders & notifications (Azure Functions)
├── InvoiceService/        # Handles invoice submissions and DB (Azure Functions + EF Core)
├── ApprovalService/       # Orchestrates approval workflow (Durable Functions)
├── PaymentService/        # Triggers payments post-approval (Azure Functions)
├── Shared/                # DTOs, Event Contracts (Class Library)
├── docs/                  # Diagrams, documentation
└── .github/               # CI/CD workflows
```

---

## Default Features

- **Invoice Submission:** Consultants submit invoices via API.
- **Automated Reminders:** Monthly notifications for pending invoices.
- **Approval Workflow:** Durable Functions orchestrate multi-step approval.
- **Payment Initiation:** Automated trigger after approvals.
- **Event-Driven Architecture:** Communication via Azure Service Bus.
- **Persistence:** SQL Server with EF Core; Repository + CQRS patterns.
- **Scalable & Testable:** SOLID principles, dependency injection, async programming.
- **Built-in CI/CD:** Sample pipeline via GitHub Actions.

---

## System Architecture

See [`docs/ARCHITECTURE.md`](docs/ARCHITECTURE.md) for:
- High-level microservices architecture
- Workflow sequence diagram
- ERD (Entity Relationship Diagram)

---

## How to Run

1. Set up Azure resources (Service Bus, SQL)
2. Update connection strings in `local.settings.json` for each service
3. Run each Function App locally or deploy to Azure Functions
4. Use APIs for invoice submission and query

---

## Contributing

> Fork, PRs welcome! See [`docs/ARCHITECTURE.md`](docs/ARCHITECTURE.md) for design decisions.

---

## License

MIT