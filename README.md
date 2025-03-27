# 🍽️ Recipe Management System

A full-stack mini project for managing recipes and ingredients, analyzing data via a RESTful API, and consuming that analysis in a console client app. Built with ASP.NET Core MVC, Web API, and C#.

---

## 📁 Project Structure

| Project | Type | Description |
|--------|------|-------------|
| `RecipeManagementSyst` | ASP.NET Core MVC | Web app to manage recipes and ingredients with full CRUD functionality |
| `RecipeManagementSystemAPI` | ASP.NET Core Web API | REST API providing analysis of ingredient usage |
| `RecipeManagementSystemClient` | Console App | Simple client that calls the API and displays popular ingredients |

---

## 💡 Features

- Manage Recipes and Ingredients (Create, Read, Update, Delete)
- In-memory data before database setup
- RESTful API: `GET /api/ingredientanalysis/popular`
- Console client that fetches and displays most popular ingredients
- Clean GitHub integration
- Modular solution with 3 separate projects

---

## 🔗 API Example Output

```json
[
  { "ingredient": "Flour", "count": 2 },
  { "ingredient": "Eggs", "count": 2 },
  { "ingredient": "Milk", "count": 1 }
]
