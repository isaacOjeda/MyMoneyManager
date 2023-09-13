# BudgetBuddy

![Logo de BudgetBuddy](/assets/temp-logo.png)

**BudgetBuddy** es una aplicación de referencia que utiliza Clean Architecture y Vertical Sliced Architecture para brindarte una visión clara de cómo crear aplicaciones de alta calidad. Aunque yo personalmente la uso para gestionar mis finanzas personales de una manera que me resulta efectiva, su verdadero propósito es servir como una herramienta educativa para aprender y enseñar sobre estas arquitecturas avanzadas.

## Nota Importante
BudgetBuddy no está diseñado específicamente para su uso generalizado en el manejo de finanzas personales. Aunque la aplicación puede ser funcional y útil para algunas personas, su principal enfoque es servir como un proyecto de aprendizaje y enseñanza de las arquitecturas Clean y Vertical Slice.

## Roadmap del Proyecto API

Aquí está nuestro plan de desarrollo para la API de BudgetBuddy:

- [x] Proyecto inicial con la implementación de la arquitectura limpia y vertical.
- [x] Implementación de autenticación mediante Bearer Tokens y Identity Core.
- [ ] Generación de cliente HTTP con NSwag para facilitar la interacción con la API.
- [ ] Gestión de Catálogos:
    - [x] Cuentas Bancarias
      - [x] Creación
      - [x] Update general
      - [x] Update de balance
      - [x] Eliminar
      - [x] Listado
    - [x] Tipos de Egresos (Opcional, se pueden agregar en la fase de inicialización)
    - [x] Tipos de Ingresos (Opcional, se pueden agregar en la fase de inicialización)
- [x] Visualización de Ingresos y Egresos por mes.
- [x] Registro de nuevos movimientos manuales (Ingreso o Egreso).
- [ ] Listado de Ingresos / Egresos programados.
  - [ ] Posibilidad de filtrar según el tipo (ingreso / egreso) y cuenta bancaria.
- [ ] Registro de nuevos Ingresos / Egresos programados.
- [ ] Resumen Mensual:
  - [ ] Representación gráfica de los movimientos según tipo y categoría.
  - [ ] Detalle de los movimientos con opción de filtrar por categoría.
- [ ] Histórico Anual:
  - [ ] Representación gráfica por mes de los movimientos.
  - [ ] Opción de filtrar por categoría.
- [ ] Notificaciones
  - [ ] Proyecciones de mes con dinero negativo o bajo en cuentas de cheques

## Roadmap del Proyecto Blazor

- [ ] Creación de una plantilla con Bootstrap.
- [ ] Desarrollo de componentes reutilizables, incluyendo grids, autocompletes, modales, y más.
- [ ] Implementación de registro de usuarios para permitir el acceso a múltiples usuarios.
- [ ] Autenticación de usuarios para garantizar la seguridad y la privacidad de los datos.
- [ ] Verificación de Email para mejorar la autenticación y la seguridad de la cuenta.
- [ ] Visualización de Ingresos y Egresos por mes para una gestión financiera detallada.
- [ ] Registro de nuevos movimientos manuales, ya sea de ingresos o egresos.
- [ ] Listado de Ingresos / Egresos programados con opciones de filtrado por tipo y cuenta bancaria.
- [ ] Registro de nuevos Ingresos / Egresos programados para una planificación financiera efectiva.
- [ ] Resumen Mensual con representación gráfica de los movimientos por tipo y categoría, así como la opción de filtrar por categoría.
- [ ] Histórico Anual con representación gráfica por mes de los movimientos y la capacidad de filtrar por categoría.
