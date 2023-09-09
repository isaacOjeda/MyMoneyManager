# BudgetBuddy

![Logo de BudgetBuddy](/assets/temp-logo.png)

**BudgetBuddy** es una aplicación de referencia que utiliza Clean Architecture y Vertical Sliced Architecture para brindarte una visión clara de cómo crear aplicaciones de alta calidad. Aunque yo personalmente la uso para gestionar mis finanzas personales de una manera que me resulta efectiva, su verdadero propósito es servir como una herramienta educativa para aprender y enseñar sobre estas arquitecturas avanzadas.

## Nota Importante
BudgetBuddy no está diseñado específicamente para su uso generalizado en el manejo de finanzas personales. Aunque la aplicación puede ser funcional y útil para algunas personas, su principal enfoque es servir como un proyecto de aprendizaje y enseñanza de las arquitecturas Clean y Vertical Slice.

## Arquitectura

BudgetBuddy se basa en dos arquitecturas sólidas para garantizar una base robusta y modular.

### Arquitectura Limpia

La arquitectura limpia es un enfoque que se basa en la separación de responsabilidades. En BudgetBuddy, hemos dividido la aplicación en tres capas principales:

### Arquitectura Vertical

La arquitectura vertical se basa en la división de responsabilidades a través de capas, con un enfoque más centrado en módulos específicos. En BudgetBuddy, hemos estructurado la aplicación en tres capas principales:


#### Capa de Dominio

La capa de dominio contiene toda la lógica de negocio de la aplicación. Esta capa es independiente de las capas de aplicación e infraestructura, lo que garantiza una clara separación de responsabilidades y la facilidad de mantenimiento.

#### Capa de Aplicación

La capa de aplicación alberga los casos de uso de la aplicación. Depende de la capa de dominio pero está desacoplada de la capa de infraestructura, lo que permite una fácil escalabilidad y reutilización de código.

#### Capa de Infraestructura

La capa de infraestructura contiene las implementaciones concretas de los puertos definidos en la capa de dominio. Esta capa es esencial para la ejecución de la aplicación y, al depender de la capa de dominio, garantiza una conexión sólida entre la lógica de negocio y la infraestructura.

#### Capa de Presentación (Endpoints)

La capa de presentación incluye los endpoints de la aplicación, lo que permite la interacción con los usuarios y otros sistemas. Depende de la capa de aplicación e infraestructura para proporcionar una experiencia de usuario fluida y eficaz.

#### Aplicación Cliente (Blazor)

La aplicación cliente se encarga de consumir los endpoints de la aplicación, proporcionando una interfaz de usuario intuitiva y atractiva. Esta aplicación depende de la capa de presentación para ofrecer una experiencia de usuario excepcional.

#### Capa de Presentación

La capa de presentación actúa como la interfaz de usuario de la aplicación, proporcionando a los usuarios la capacidad de interactuar con la funcionalidad. Depende de la capa de aplicación e infraestructura para brindar una experiencia de usuario completa.

#### Capa de Aplicación

La capa de aplicación contiene la lógica de negocio de la aplicación y los casos de uso específicos. Dependiendo de la capa de infraestructura para acceder a los recursos subyacentes, esta capa se encarga de ejecutar las funcionalidades principales de BudgetBuddy.

#### Capa de Infraestructura

La capa de infraestructura proporciona las implementaciones concretas de los componentes utilizados por la capa de aplicación. Al depender de la capa de aplicación, garantiza una sólida conexión entre la funcionalidad de la aplicación y la infraestructura subyacente.

## Roadmap del Proyecto API

Aquí está nuestro plan de desarrollo para la API de BudgetBuddy:

- [ ] Proyecto inicial con la implementación de la arquitectura limpia y vertical.
- [ ] Implementación de autenticación mediante Bearer Tokens y Identity Core.
- [ ] Generación de cliente HTTP con NSwag para facilitar la interacción con la API.
- [ ] Gestión de Catálogos:
    - [ ] Cuentas Bancarias (CRUD)
    - [ ] Tipos de Egresos (Opcional, se pueden agregar en la fase de inicialización)
    - [ ] Tipos de Ingresos (Opcional, se pueden agregar en la fase de inicialización)
- [ ] Visualización de Ingresos y Egresos por mes.
- [ ] Registro de nuevos movimientos manuales (Ingreso o Egreso).
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
