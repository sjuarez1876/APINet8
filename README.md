Caracterisicas de la Api:

Consulta y agregaga registros

la api permite consultar datos y permitiendo agregar registros a una tabla de sqlserver. 
Por cada solicitud devuelve un json con un  mensaje  descriptivo de exepción, alerta y/o exitoso y con un código de mensaje

implementación con Net8 (core) se llevo a cabo el uso de interfaces y clases y entity framework core para el acceso a datos. y se llevo a cabo el uso de modelos.

realiza validaciones:

para longitud no mayor a 50 caracteres en el caso del nombre
para el correo retorna un mensaje en caso de que el formato del correo sea invalido
y para el caso del campo edad retorna solo contenga números

El patrón de diseño que se utilizó fue para la construcción de la solución fue el tipo Abstract Factory
