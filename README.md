# Task Management System

This project is a CRUD (Create, Read, Update, Delete) application for managing tasks and users, designed to function similarly to popular task management tools like Jira. It allows users to assign tasks to specific individuals, add, update, and remove both tasks and users.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Installation](#installation)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Environments](#environments)

## Introduction

This project provides a simple and effective way to manage tasks within a team. Users can create tasks, assign them to team members, and update or delete them as needed. Additionally, users can manage the list of team members.

## Features

- **Task Management:**
  - Create tasks with titles, descriptions.
  - Assign tasks to specific users.
  - Update task details.
  - Remove tasks.

- **User Management:**
  - Add new users to the system.
  - View the list of users.
  - Remove users.

## Technologies Used

- **Backend:**
  - [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/)
  - [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
  - [SQL Server](https://www.microsoft.com/en-us/sql-server) (or any other preferred database)

- **Frontend (Optional):**
  - Use your preferred frontend framework (Blazor, Angular, React, etc.) if applicable.

## Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/your-username/task-management-system.git
    ```

2. Open the solution in your preferred IDE (Visual Studio, Visual Studio Code, etc.).

3. Set up the database:
    - Create a SQL Server database and update the connection string in the configuration file.

4. Run the application.

## Usage

1. Access the application through the provided URL (default: http://localhost:5000 or https://localhost:5001 for HTTPS).
2. Create users and tasks through the provided UI or API.

## API Endpoints

- **List of Endpoints:**

- *Task:*
  - `GET /api/Tasks`: Get the list of all tasks.
  - `POST /api/Tasks`: Create a new task.
  - `DELETE /api/Tasks/{id}`: Remove a task.
  - `GET /api/Tasks/{id}`: Get tasks by id.
  - `PUT /api/Tasks/{id}`: Update task details.
    
- *User:*
  - `GET /api/Users`: Get the list of all users.
  - `POST /api/Users`: Create a new user.
  - `DELETE /api/Users/{id}`: Remove a user.
  - `GET /api/User/{id}`: Get user by id.
  - `PUT /api/User/{id}`: Update user details.

## Environments

The application supports different environments for development and production. Ensure to set the appropriate environment variable (`ASPNETCORE_ENVIRONMENT`) when running the application.

- For Development:

  ```bash
  ASPNETCORE_ENVIRONMENT=Development

- For Production:

  ```bash
  ASPNETCORE_ENVIRONMENT=Production

## Testing

The project includes both unit and integration tests to ensure the reliability and functionality of the codebase.

To run the tests, use NUnit and execute the corresponding test commands.


