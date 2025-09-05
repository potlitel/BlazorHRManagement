# 🧑‍💼 HR Management - Simple Sample Web API

Este repositorio contiene un proyecto web API simple que simula una aplicación básica de Gestión de Recursos Humanos (HR Management).

## 📄 Descripción

Este proyecto ofrece una API REST sencilla para gestionar empleados, departamentos y roles dentro de una organización. Es ideal para aprender conceptos fundamentales de desarrollo de APIs con .NET Core y para experimentar con operaciones CRUD básicas aplicadas a un sistema HR.

## 📦 Contenido

- Código fuente de la API construido con .NET Core Web API.
- Controladores para manejo de empleados, departamentos y roles.
- Modelos de datos y lógica básica de negocio.
- Ejemplos de solicitudes y respuestas API.
- Documentación para consumir la API.

## ⚙️ Requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) versión 6.0 o superior.
- Herramienta para probar APIs (Postman, curl, etc.).
- Editor o IDE compatible (Visual Studio, VS Code).

## ▶️ Cómo ejecutar

1. Clonar el repositorio:

```bash
git clone https://github.com/tuusuario/hr-management.git
cd hr-management
```

2. Restaurar paquetes y compilar el proyecto:

```bash
dotnet restore
dotnet build
```

3. Ejecutar la API:

```bash
dotnet run
```

3. Ejecutar la API:


4. Probar los endpoints API desde Postman o cualquier cliente HTTP. Por ejemplo:
- `GET /api/employees` — Lista de empleados.
- `POST /api/employees` — Crear un nuevo empleado.
- `PUT /api/employees/{id}` — Actualizar empleado.
- `DELETE /api/employees/{id}` — Eliminar empleado.

## 🎯 Objetivos futuros

- Añadir autenticación y autorización.
- Implementar paginación y filtros.
- Añadir documentación Swagger/OpenAPI.
- Incorporar pruebas unitarias e integración.

---

Este proyecto es ideal para quienes quieren iniciar en el desarrollo de APIs REST con .NET Core en un contexto de aplicación HR simple.

---

¡Contribuciones, sugerencias y feedback son bienvenidos!

