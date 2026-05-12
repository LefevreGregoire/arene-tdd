# Arene TDD

Ce projet implémente une logique de combat au tour par tour entre gladiateurs en utilisant le langage C# et le framework .NET. Il a été réalisé en appliquant rigoureusement la méthodologie TDD (Test-Driven Development) avec un historique de commits reflétant les cycles d'itération (Red, Green, Refactor).

## Architecture et Concepts

Le projet est structuré en deux parties :
- **Arene** : La bibliothèque de classes contenant la logique métier (Gladiator, classes et interfaces liées au système de dé).
- **Arene.Tests** : Le projet de tests unitaires utilisant le framework xUnit.

Afin de rendre les tests déterministes malgré un système de dégâts basé sur l'aléatoire, le principe d'Inversion de Contrôle (IoC) a été appliqué. La classe `Gladiator` dépend d'une abstraction `IDice` plutôt que d'une implémentation concrète. Cela permet l'injection d'un dé truqué (mock) lors de l'exécution des tests unitaires.

## Règles métier implémentées

Les règles suivantes ont été implémentées et sont couvertes par les tests :
- Validation de l'intégrité du dé (valeurs restreintes de 1 à 6).
- Interdiction pour un gladiateur de cibler sa propre instance lors d'une attaque.
- Calcul des dégâts standard : (Valeur du dé + Force de l'attaquant) - Armure du défenseur.
- Gestion du coup critique : Si le jet de dé est égal à 6, la base de dégâts (Dé + Force) est multipliée par deux avant soustraction de l'armure.
- Les points de vie d'un gladiateur sont plafonnés à un minimum de zéro (pas de santé négative en cas de dommages excessifs).
- L'armure ne peut pas soigner un gladiateur si elle est supérieure aux dégâts infligés.

## Prérequis

- .NET SDK 8.0 (ou version ultérieure)

## Utilisation

Pour compiler la solution :
```bash
dotnet build
```

Pour exécuter la suite complète des tests unitaires :

```bash
dotnet test
```
