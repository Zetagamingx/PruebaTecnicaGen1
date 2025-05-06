# PruebaTecnicaGen1

Para el punto 1. Generacion Aleatoria de Objetos se utilizo un Object Pooling. Como se condiciona a 10 objetos como maximo, se elimino el añadir un objeto a la lista cuando no hubiera objetos desactivados. Asi se asegura que si o si al tener 10 Activos y ninguno libre
no se instancie nada mas. 

 

Para el punto 2. Simplemente los datos que se muestran en el TextMeshProGUI son enviados desde el script que maneja la generacion aleatoria y desde el objeto que se geneor al destruirse.

Bonus de la generacion aleatoria con colores aleatorios, se puso una funcion RandomColor cuyo return lo usamos para seleccionar un material usando un Array desde el objeto del Object pooling a traves de un Switch.

Bonus de destuir al hacer click, se utilizo el InputSystem_Actions implementado su interfaz en el script de PlayerController para mejor lectura y usabilidad. Se usó la funcion OnAttack del IPlayerActions para obtener datos de un raycast en conjunto con la posicion del cursor en relacion a la vista de la camara. 
En caso tal de realizar click izquierdo el raycast compara el tag y el layer del objeto que esta detectando y en caso de ser los correctos, llama la funcion de este mismo objeto llamado AttackObject que le hace que se desactive, aplicando tambien el envio de informacion necesaria al punto 2. 

Enlace video de muestra https://youtu.be/PvwPJmBhBr8
