# Estandarizacion Backend <a name="bid0"></a>

## Indice

- [Variables](#bid1)
  - [Tabla de prefijos](#bid2)
  - [Nombramiento de variables](#bid3)
- [Clases, funciones y metodos](#bid4)
  - [Clases](#bid5)
  - [Nombres](#bid6)
  - [Funciones](#bid7)
  - [Tabla de Sufijos](#bid8)
- [Principios de programacion](#bid9)
  - [SOLID](#bid10)
  - [DRY](#bid11)
- [Estructura](#bid12)
  - [DAO](#bid13)
  - [Models](#bid14)
  - [Service](#bid15)
  - [Controllers](#bid16)
  - [Configs](#bid17)
- [Estructura de paquetes](#bid18)


**** 
## Variables <a name="bid1"></a>
Utilizar nombres significativos y pronunciables para variables utilizando prefijos del tipo y en ingles.
**** 
### Tabla de Prefijos <a name="bid2"></a>
| Tipo de Variable | Nota            | Prefijo             |
|------------------|-----------------|---------------------|
| String           |                 | str                 |
| Int              |                 | int                 |
| Bool             |                 | bln                 |
| Double           |                 | dbl                 |
| Char             |                 | chr                 |
| Float            |                 | flt                 |
| Long             |                 | lng                 |
| Short            |                 | sht                 |
| Struct           |                 | stc                 |
| Object           | Objetos creados | obj                 |
| Array            |                 | arr                 |
| List, ArrayList  |                 | lst                 |
| Hashmap          |                 | hsm                 |
| Dictionary       |                 | dict                |
| Byte             |                 | byt                 |
| Datatime         |                 | dtm                 |
| Const            |                 | cnt`<TipoVariable>` |
| BigInt           |                 | bint                |
**** 
### Nombramiento de variables <a name="bid3"></a>
- Utilizar nombres significativos y pronunciables.
- Utilizar prefijos del tipo de variable definidos anteriormente .
- Las variables deben estar en inglés. 
- Usar lowerCamelCase.
- No usar caracteres especiales y tampoco numéricos.
- Crear variable constante para valores inmutables. __(Variables que no cambian de valor)__.
- Para variables tipo lista, utilizar plural.
- Para variables tipo boolean, utilizar prefijos __blnIs__, __blnHas__, __blnCan__.
- Variable tipo numérico, escoger palabras que describan números como `<prefijo>`Max, `<prefijo>`Min o `<prefijo>`Total.

#### Ejemplos

```csharp
bool blnIsActive = true;
const string cntStrName = 'Timoteo';
double dblTax = 0.00002;
```

**Nota:** lowerCamelCase, cuando la primera letra de cada una de las palabras es mayúscula, con la excepción de que la primera letra es minúscula.

## Clases, funciones y metodos <a name="bid4"></a>
**** 
### Clases <a name="bid5"></a>
Las clases y los objetos deben tener nombres formados por un sustantivo o frases de sustantivo como User, UserProfile, Account o AdressParser. Debemos evitar nombres genéricos como Manager, Processor, Data o Info.

Hay que ser cuidadosos a la hora de escoger estos nombres, ya que son el paso previo a la hora de definir la responsabilidad de la clase. Si escogemos nombres demasiado genéricos tendemos a crear clases con múltiples responsabilidades.
**** 
### Nombres <a name="bid6"></a>
- Evitar el uso de tipos de datos en los nombres
- No tener mismas clases, metodos/funciones con la misma funcionalidad, evitar repetir acciones.

```csharp
//Malo
getUserInfoObj();
getClientDataObj();
getCustomerRecorObj();

//Bueno
getUserObj();
```
**** 
### Funciones <a name="bid7"></a>
Se utilizará un prefijo con base a la acción, seguido de la descripción corta del método y un sufijo dependiendo el valor que retorna.
- Se utilizará un prefijo con base a la acción.
- Las funciones y métodos deben de realizar una sola acción. 
- Si los argumentos son más de 3, se deberá enviar objeto serializado.
- Las funciones deben de tener un tamaño de líneas reducido.
- No duplicar acciones y código.
**** 
### Tabla de Sufijos <a name="bid8"></a>
| Accion     | Contexto                 | Sufijo |
|------------|--------------------------|--------|
| Obtener    | Obtener informacion      | get    |
| Asignar    | Asignar informacion      | set    |
| Actualizar | Actualizar informacion   | update |
| Eliminar   | Eliminar informacion     | delete |
| Cambiar    | Intercambiar informacion | change |
| Crear      | Crear objetos            | create |
| Enviar     | Enviar informacion       | send   |
**** 
## Principios de programacion <a name="bid9"></a>
### **SOLID** <a name="bid10"></a>
- __S: Single responsibility principle__ o Principio de responsabilidad única
- __O: Open/closed principle__ o Principio de abierto/cerrado
- __L: Liskov substitution principle__ o Principio de sustitución de Liskov
- __I: Interface segregation principle__ o Principio de segregación de la interfaz
- __D: Dependency inversion principle__ o Principio de inversión de dependencia
****
#### __S: Principio de responsabilidad única__
Como su propio nombre indica, establece que una clase, componente o microservicio debe ser responsable de una sola cosa.

#### __O: Principio abierto/cerrado__
Establece que las entidades software (clases, módulos y funciones) deberían estar abiertos para su extensión, pero cerrados para su modificación.

#### __L: Principio de substitución de Liskov__
Declara que una subclase debe ser sustituible por su superclase, y si al hacer esto, el programa falla, estaremos violando este principio.

#### __I: Principio de segregación de interfaz__
Este principio establece que los clientes no deberían verse forzados a depender de interfaces que no usan.

### __D: Principio de inversión de dependencias__
Establece que las dependencias deben estar en las abstracciones, no en las concreciones. Es decir:
- Los módulos de alto nivel no deberían depender de módulos de bajo nivel. Ambos deberían depender de abstracciones.
- Las abstracciones no deberían depender de detalles. Los detalles deberían depender de abstracciones.
***

### **DRY: Don't Repeat Yourself** <a name="bid11"></a>
 Establece que, en un entorno informático, la información no debe repetirse. Es decir, el conocimiento almacenado en un programa informático debe mantenerse en un, y sólo en un, lugar.

****
## Estructura <a name="bid12"></a>
Utilizaremos una mezcla de los patrones Repository con la estructura de patron DAO.

### **Paquete DAO**<a name="bid13"></a>
En este paquete tendremos todas las intefaces que implementaremos, para el nombramiento de las clases sera **`<NombreClase>Dao` (Data Access Object)**.
#### Ejemplo
```csharp
public interface ProductDao {
    public Task<int> Save(ProductDto product);

    public Task<List<ProductDto>> GetAll();
}
```
En este mismo paquete tambien iran en una carpeta aparte las implementaciones, se nombraran de la siguiente manera **`<NombreClase>DaoImpl` (Data Access Object Implement)** . 

#### Ejemplo
```csharp
public class ProductDaoImpl : ProductDao
    {
    public async Task<List<ProductDto>> GetAll(){...}

    public async Task<int> Save(ProductDto product){...}      
}
```
****
### **Paquete Models** <a name="bid14"></a>
En este paquete iran todas las clases que esten relacionadas con la base de datos, utilizaremos las anotaciones, las clases tendran el sufijo DTO, **`<NombreClase>Dto` (Data Transfer Object)**.

#### Ejemplo
```csharp
public class ProductDto
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int intId { get; set; }

        [Column("fist_name")]
        public string strFirstName { get; set; }

        [Column("description")]
        public string strDescription { get; set; }

        [Column("img")]
        public string strImg { get; set; }

        [Column("review")]
        public int strReview { get; set; }

        public ProductDto(){...}
    }
```
****
### **Paquete Services** <a name="bid15"></a>
Aca pondremos la interfaz que querramos implementar con los siguientes sufijos en el nombramiento de la clase **`<NombreClase>Svc` (Services)**.
#### Ejemplo
```csharp
public interface ProductSvc
    {
        public Task<int> saveProduct(Product product);
        public Task<List<Product>> getProducts();    
    }
```
Tambien contendra un paquete **Models** tendremos todos los modelos con los que vamos a responder en la llamada, el nombramiento es el siguiente **`<NombreClase>`**.

#### Ejemplo
```csharp
public class Product
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string img { get; set; }

        public int review { get; set; }

        public Product(){ ... }
    }
```

Contendra otro paquete llamado **Impl** donde tendra las implementaciones de las clases interfaz, estas tendran el nombre de **`<NombreClase>SvcImpl` (Service Implement)**, en este paquete debe ir toda la logica de programacion, no debera haber nada de logica en ninguna otra capa.

#### Ejemplo 
```csharp
public class ProductSvcImpl : ProductSvc
    {
        public ProductDao product;
        public ProductSvcImpl(ProductDao product)
        {
            this.product = product;
        }

        public async Task<List<Product>> getProducts()
        {
            IEnumerable<ProductDto> products = await this.product.GetAll();
            return products.Select(product => new Product
            {
                id = product.id,
                description = product.description,
                img = product.img,
                name = product.name, 
                review  = product.review
               
            }).ToList();

        }

        public async Task<int> saveProduct(Product product)
        {
            ProductDto newProduct = new ProductDto();
            newProduct.name = product.name;
            newProduct.description = product.description;
            newProduct.img = product.img;
            newProduct.review = product.review;
            return await this.product.Save(newProduct);
        }
    }
```
****
### **Paquete Controllers** <a name="bid16"></a>
En este paquete se encontraran el servicio expuesto para que pueda ser consumido, el nombramiento sera el siguiente **`<NombreClase>Controller`**, **los endpoints deben estar en minusculas**.
#### Ejemplo
```csharp
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductSvc productSvc;

    public ProductsController(ApiDbContext apiDbContext) {
        productSvc = new ProductSvcImpl(new ProductDaoImpl(apiDbContext));
    }
    
    [HttpGet]
    public async Task<List<Product>> Get()
    {
        return await productSvc.getProducts();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Product product)
    {

        return Ok(await this.productSvc.saveProduct(product));
    }

    ...
}
```


****
### **Paquete Config** <a name="bid17"></a>
En este paquete iran todas las configuraciones provenientes al contexto de la base de datos.

### Ejemplo
```csharp
public class ApiDbContext : DbContext
{
    public DbSet<ProductDto> Products { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options){...}

}

```
****
### Estructura de paquetes <a name="bid18"></a>
- Raiz
    - DAO
        - Impl
            - ProductDaoImpl.cs
            - ...
        - IDao.cs
    - Models
        - ProductDto.cs
        - ...
    - Service
        - Impl
            - ProductSvcImpl.cs
            - ...
        - Models
            - Product.cs
            - ...
        - ISvc.cs
    - Controllers
        - ProductController.cs
        - ...
    - Config
        - ApiDbContext.cs
        - ...
    - ...


## Respuestas
- Para las respuestas se tiene que crear una clase con los códigos de respuestas, ya sea para correctos o incorrectos.
- [Códigos de respuestas HTTP](https://developer.mozilla.org/es/docs/Web/HTTP/Status)
- Códigos de respuestas personalizados, crear una clase

Se implementara una clase Mensaje donde tendremos el codigo, el nombre entre otros.

#### Ejemplo
```csharp
class Message{
    public int code { get; set; } 
    public string message { get; set; }
    ... 
}
```
Su implementacion es una clase donde se crearan los diferentes tipos de mensaje.

```csharp
class ResponseMessage{
    public Message notFound(){
        return new Message(404, 'No encontrado');
    }
    ...
}
```
***

## Comandos de ejecución
Para la ejecucion de los proyectos en la terminal en entorno de desarrollo se puede utilizar los siguientes comandos: 

```{bash}
    
    dotnet run --launch-profile EnvironmentsSample-Staging

```

Los entornos del proyecto se configuran en lauchSettings.json con la siguiente estructura

```json
    
    "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:57979/",
      "sslPort": 44388
    }
  },
  "profiles": {
       "EnvironmentsSample-Staging": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Staging"
      }
    }
  }

```

***

## Versionamiento
Para el versionamiento usaremos GitFlow

### Ramas

- **main**: rama maestra, contiene el codigo estable que esta en produccion.
- **develop**: rama para desarrollo.
- **feature**: rama para nuevos desarrollos, sale y cae de la rama develop.
- **hotfix**: rama para cambios urgentes, entra y sale de la rama main.
- **release**: rama para lanzar una nueva version, sale de develop y entra a main.

****
### Mensajes en Commits
Para los commits tendremos que agregar un mensaje especial para que se identifique de mejor forma, tambien debemos hacer cambios simples para un mejor seguimiento del codigo.

```
MOD: responde Product controller
ADD: User class
DEL: remove change function in user class
```

