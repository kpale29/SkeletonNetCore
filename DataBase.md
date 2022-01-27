# Estandarizacion de Base de Datos
Para la estandarizacion de la base de datos deberemos de seguir las siguientes reglas.

## Indice

- [Tablas](#id1)
- [Procedimientos Almacenados](#id2)
- [Funciones](#id3)
- [Triggers](#id4)


## Tablas <a name="id1"></a>
- [Formas Normales](https://blog.bi-geek.com/modelo-relacional-formas-normales/).
- Utilizar ***snake_case***.
    - ***Snake case*** es la convención que compone las palabras separadas por barra baja (underscore) en vez de espacios y con la primera letra de cada palabra en minúscula, aplica para tablas y propiedades de las tablas.
- Nombres en singular.
- Utilizar prefijo acorde al esquema en la tabla a crear.
- Nombres de atributos en ingles.
- Nombres de funciones, stored procedures, triggers y tablas en ingles.
- No utilizar **relacion muchos a muchos**.
- La tabla solo debe llevar id, un mal uso seria `employee_id` para una llave primaria, dado que se esta referenciando a la misma tabla.
- Deben usarse constraints.
    - pk_`<NombreConstraint>` para llaves primarias.
    - fk_`<TablaOrigen>_<TablaActual>` para llaves foraneas.

### Ejemplo
```sql
CREATE TABLE bank_employee(
    id serial not null,
    first_name varchar(30) not null,
    last_name varchar(30) not null,
    ...,
    constraint pk_employee primary key (id)
);

CREATE TABLE bank_order(
    id serial not null,
    employee_id int not null,
    ...,
    constraint pk_order primary key (id),
    constraint fk_employee_order foreign key (employee_id) references (bank_employee)
);

```
****
## Procedimientos Almacenados <a name="id2"></a>
Para los procedimientos almacenados se debe anteponer el prefijo **sp** al nombre del stored procedure **`sp_<NombreStoredProcedure>`**.
### Ejemplo
```sql
CREATE PROCEDURE sp_nombre_procedimiento(<Lista de parametros>) AS $$
DECLARE
    ...
BEGIN
    ...
    ...
END
```
****
## Funciones <a name="id3"></a>
Para la creacion de funciones debemos que anteponerle **func** al nombre de la funcion a crear **`func_<NombreFuncion>`**.
### Ejemplo
```sql
CREATE FUNCTION func_nombre_funcion(<Lista de parametros>) RETURNS TRIGGER AS $$
BEGIN
    ...
    ...
END
```
****
## Triggers <a name="id4"></a>
Para los triggers tenemos que anteponerle el prefijo **trg** al nombre del trigger **`trg_<NombreTrigger>`**.

### Ejemplo
```sql
CREATE TRIGGER trg_nombre_trigger BEFORE INSERT ON tabla FOR EACH ROW EXECUTE PROCEDURE func_nombre_funcion;
```