**Cronograma de Actividades (90 minutos)**
*(Objetivo: minimizar conflictos en Git y completar la práctica lo más rápido posible)*

### Fase 1: Preparación Inicial (0 – 10 min)

| Tiempo (min) | Actividad                                                                                                                        | Responsable(s) |
| ------------ | ------------------------------------------------------------------------------------------------------------------------------- | -------------- |
| **0 – 10**   | 1. Clonar repositorio y asegurarse de estar en la rama `develop`.<br>2. Cada integrante crea su rama `feature/XXX-nombre` para la tarea asignada.<br>3. Confirmar que el proyecto base MVC está compilando correctamente. | Todos          |

### Fase 2: Modelo, BD y Estructura (10 – 25 min)

| Tiempo (min) | Actividad                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           | Responsable(s)                   |
| ------------ | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------- |
| **10 – 25**  | 1. **Definición de Modelo y BD:**<br>   • Angel: crear rama `feature/angel-modelo-producto` y definir modelo `Producto` (Id, Nombre, Descripción, Precio, Stock, ImagenURL). Crear migración e implementar en `ApplicationDbContext`.<br>   • Dave: crear rama `feature/dave-dbconfig` y configurar cadena de conexión (appsettings.json) y agregar `ApplicationDbContext` a `Startup.cs` (o `Program.cs`).<br>2. **Estructura de Carpetas:**<br>   • Diego: crear rama `feature/diego-estructura-admin` y crear carpetas `Controllers/Admin` y `Views/Admin`.<br>   • Iti: crear rama `feature/iti-estructura-home` y crear carpetas `Controllers/Home` y `Views/Home`.<br>3. **Integración AdminLTE:**<br>   • Gonzalo: crear rama `feature/gonzalo-adminlte` e incorporar archivos estáticos de AdminLTE (CSS, JS) en `wwwroot`, y adaptar el archivo `_LayoutAdmin.cshtml` en `Views/Shared`. | Angel, Dave, Diego, Iti, Gonzalo |

### Fase 3: CRUD y Vistas Admin (25 – 45 min)

| Tiempo (min) | Actividad                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           | Responsable(s)                   |
| ------------ | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------- |
| **25 – 45**  | 1. **CRUD en Área de Admin:**<br>   • Angel: en su rama, crear `Admin/ProductController` con acciones `Index()`, `Create()`, `Edit()`, `Delete()`.<br>   • Dave: crear vistas Razor para CRUD (`Index.cshtml`, `Create.cshtml`, `Edit.cshtml`, `Delete.cshtml`) en `Views/Admin/Product`.<br>   • Gonzalo: personalizar `_LayoutAdmin.cshtml` (navbar, sidebar) y enlazar menús con rutas de `ProductController`.<br>2. **Integración de Modelo y Controlador:**<br>   • Diego: revisar que `ProductController` use correctamente el `DbContext`; implementar inyección de dependencias (`IServiceCollection`).<br>   • Iti: validar que los campos del modelo coincidan en las vistas (etiquetas `asp-for`). | Angel, Dave, Diego, Iti, Gonzalo |

### Fase 4: Seguridad y Validaciones (45 – 55 min)

| Tiempo (min) | Actividad                                                                                                                                                                                                                                   | Responsable(s)         |
| ------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ---------------------- |
| **45 – 55**  | 1. **Autenticación y Autorización:**<br>   • Dave: asegurar que el área de Admin requiera autenticación y rol adecuado.<br>   • Angel: probar acceso restringido y redirecciones.<br>2. **Validación de Datos:**<br>   • Iti: agregar y probar DataAnnotations en el modelo Producto.<br>   • Diego: mostrar mensajes de error en las vistas. | Dave, Angel, Iti, Diego |

### Fase 5: Vista Pública y Servicios (55 – 65 min)

| Tiempo (min) | Actividad                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     | Responsable(s)                |
| ------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------- |
| **55 – 65**  | 1. **Vista Pública (Home):**<br>   • Iti: crear `HomeController` con acción `Index()` que obtenga lista de productos (`_context.Productos.ToList()`).<br>   • Diego: diseñar vista `Views/Home/Index.cshtml`, mostrar listado de productos en tarjetas simples (imagen, nombre, precio).<br>2. **Servicios y Depuración:**<br>   • Gonzalo: verificar servicios (`IProductService`) y añadir capa opcional de repositorio si el tiempo lo permite; si no, usar acceso directo desde `DbContext`.<br>   • Angel y Dave: pruebas manuales rápidas de inserción y edición de productos en Admin; corregir errores de validación (DataAnnotations) y rutas. | Iti, Diego, Gonzalo, Angel, Dave |

### Fase 6: Integración y Pruebas Combinadas (65 – 75 min)

| Tiempo (min) | Actividad                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              | Responsable(s)                   |
| ------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------- |
| **65 – 75**  | 1. **Integración de Branches y Resolución de Conflictos:**<br>   • Cada quien hace `git add/commit` local cada 5 min.<br>   • Todos hacen merge de sus ramas `feature/XXX-nombre` a `develop`.<br>   • Si se requiere una revisión intermedia, crear rama `release/vX.Y` desde `develop` para pruebas.<br>   • Gonzalo: resuelve conflictos mínimos (rutas, layouts).<br>2. **Pruebas Combinadas:**<br>   • Iti y Diego: validar que, tras el merge, la vista pública liste los productos creados en Admin.<br>   • Gonzalo: verificar que AdminLTE no haya roto nada en el layout público. | Angel, Dave, Iti, Diego, Gonzalo |

### Fase 7: Revisión Final y Documentación (75 – 90 min)

| Tiempo (min) | Actividad                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              | Responsable(s)                |
| ------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------- |
| **75 – 85**  | 1. **Revisión de Usabilidad y Presentación:**<br>   • Todos: revisar que la navegación sea clara, que los formularios sean usables y que los mensajes de error sean comprensibles.<br>   • Gonzalo: ajustar detalles visuales en AdminLTE y Home si es necesario.<br>2. **Documentación:**<br>   • Dave: actualizar README con instrucciones de despliegue y uso.<br>   • Angel: documentar estructura de carpetas y dependencias principales. | Todos, Dave, Angel, Gonzalo |
| **85 – 90**  | 1. **Commit Final y Push a `main`:**<br>   • Todos revisan que no queden archivos sin commitear.<br>   • Gonzalo coordina el merge de `develop` a `main` (solo desde develop), genera el último commit con mensaje claro (“Práctica ASP.NET Core MVC – CRUD y Home implementados”).<br>2. **Validación Final:**<br>   • Ejecutar aplicación en modo Debug/Release y confirmar que Admin y Home funcionan sin errores.<br>   • Preparar breve demo (quién expone y en qué orden: Admin primero, luego vista pública). | Todos                        |

---

## Estrategia de Ramas (Git Flow Adaptado)

- `develop`: integra todas las features y es la rama base para merges de desarrollo.
- `feature/XXX-nombre`: cada integrante crea su propia rama para la tarea asignada (ejemplo: `feature/angel-modelo-producto`).
- `release/vX.Y`: solo si se requieren pruebas intermedias antes de producción o demo, se crea desde `develop`.
- `main`: versión lista para demos, solo recibe merges desde `develop`.

---

## Notas de Estrategia para Evitar Conflictos

1. **Ramas de Funcionalidad (Feature Branches):**

   * Usar ramas `feature/XXX-nombre` para cada tarea asignada.
   * Siempre trabajar en la rama correspondiente y hacer “pull” de `develop` antes de iniciar cambios.

2. **Commits Frecuentes y Mensajes Claros:**

   * Cada tarea o paso significativo debe comitearse cada 5–10 min.
   * Mensajes tipo:

     * `git commit -m "Agregar modelo Producto y migración inicial"`
     * `git commit -m "Configurar DbContext y cadena de conexión"`
     * `git commit -m "Crear ProductController con acciones CRUD"`

3. **Integración Temprana de AdminLTE:**

   * Integrar los assets (CSS/JS) de AdminLTE durante la fase temprana (min 10–25) para que nadie esté trabajando simultáneamente sobre `_LayoutAdmin.cshtml`.
   * Mantener el layout público (`_Layout.cshtml`) por separado de `_LayoutAdmin.cshtml`.

4. **Asignación Clara de Responsabilidades:**

   * Mientras Ángel y Dave trabajan en modelo, controlador y vistas de CRUD, quienes trabajan en la vista pública (Iti y Diego) no tocan esos mismos archivos.
   * Gonzalo coordina merges y se encarga de la parte de servicios/DI para que no hayan colisiones en `Startup.cs` o `Program.cs`.

5. **Validaciones y Pruebas Manuales Continuas:**

   * A medida que se implementa cada acción de CRUD, probar inmediatamente (min 45–50) para detectar errores de rutas o validaciones.
   * Después del merge (min 65–80), ejecutar conjuntamente flujo de crear producto → visualizar en Home.

6. **Merge Final Temprano:**

   * Idealmente, integrar todas las ramas `feature/XXX-nombre` en `develop` antes de abordar la vista pública, para que quien trabaje en Home haga “pull” de lo último de las entidades de `Producto`.
   * Evita ediciones simultáneas en modelos o layouts.

---

## Instructivo Básico de Git: Crear, Cambiar y Unir Ramas

### 1. Crear una nueva rama para tu tarea

```powershell
git checkout develop
git pull
git checkout -b feature/tu-nombre-tarea
```

- Reemplaza `tu-nombre-tarea` por el nombre de tu tarea, por ejemplo: `feature/angel-modelo-producto`.

### 2. Cambiar entre ramas existentes

```powershell
git checkout nombre-de-la-rama
```

- Por ejemplo: `git checkout develop` o `git checkout feature/angel-modelo-producto`

### 3. Unir tu rama de feature a develop

1. Asegúrate de estar en develop y actualizado:

```powershell
git checkout develop
git pull
```

2. Haz merge de tu rama:

```powershell
git merge feature/tu-nombre-tarea
```

3. Si hay conflictos, resuélvelos y luego:

```powershell
git add .
git commit -m "Resolver conflictos de merge"
```

4. Sube los cambios:

```powershell
git push
```

### 4. Unir develop a main (solo para versión lista para demo)

```powershell
git checkout main
git pull
git merge develop
git push
```

---

**Consejos:**
- Haz `git pull` antes de empezar a trabajar y antes de hacer merge.
- Usa mensajes de commit claros.
- Si necesitas una rama de pruebas intermedia, crea una rama `release/vX.Y` desde develop.

Con este cronograma y las prácticas de Git descritas, podrán avanzar en paralelo sin pisarse, terminar en los 90 min establecidos y presentar una demo funcional de la tienda de videojuegos en ASP.NET Core MVC.
