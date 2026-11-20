# Mini-Studio

Une petite plateforme pour créer, configurer et interroger des assistants IA, sur le modèle d'un « studio » d'agents interne.

C'est un projet d'apprentissage : je l'écris pour monter en compétence sur .NET/C#, Python et LangGraph. Je viens de Kotlin/Spring. Je le construis étape par étape, avec des tests à chaque étape.

## Architecture visée

```
front React (TanStack)  →  API .NET (C#)  →  service agents Python (FastAPI + LangGraph)
                               │                         │
                          base de données            RAG + évaluations
```

## Stack

| Couche | Technologies |
|---|---|
| Backend | .NET 10, ASP.NET Core Minimal API, Clean Architecture |
| Tests | xUnit |
| Agents (à venir) | Python, FastAPI, LangGraph |
| Front (à venir) | React, TanStack |
| Déploiement (à venir) | Docker Compose |

## Structure du backend

```
backend/
├── src/
│   ├── MiniStudio.Domain/          # entités et règles métier, sans dépendance
│   ├── MiniStudio.Application/     # cas d'usage, interfaces (ports)
│   ├── MiniStudio.Infrastructure/  # persistance, appels externes (adapters)
│   └── MiniStudio.Api/             # endpoints HTTP, injection de dépendances
└── tests/
    └── MiniStudio.Domain.Tests/
```

Les dépendances vont vers l'intérieur : `Api → Application → Domain`, et `Infrastructure` implémente les interfaces définies dans `Application`.

## Lancer le projet

Il faut le SDK .NET 10.

```bash
cd backend
dotnet build
dotnet test
dotnet run --project src/MiniStudio.Api
```

## Avancement

- [x] Solution .NET en Clean Architecture
- [x] Entité `Assistant` (factory, validation) et ses tests
- [x] Cas d'usage `CreateAssistant` et repository
- [ ] Endpoints REST et persistance (EF Core)
- [ ] Service Python : agent LangGraph, RAG, évaluations
- [ ] Front React + TanStack
- [ ] Docker Compose
