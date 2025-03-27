# **Autobanco Simulado - Práctica 1**

## **Descripción**
Este proyecto es una simulación de un **autobanco** desarrollado en **C#** como parte de la primera práctica del curso **Programación III** en la Universidad Mesoamericana. El sistema ofrece diversas funciones bancarias que incluyen depósitos, retiros, transferencias y compra/venta de dólares, todo gestionado de forma interactiva a través de un menú estructurado. Adicionalmente, el programa administra bóvedas de dinero, permitiendo manejar billetes de distintas denominaciones y dólares.

## **Funcionamiento del programa**
El autobanco opera con cuatro estaciones de servicio y cuatro bóvedas (tres en quetzales y una en dólares). Estas bóvedas almacenan el dinero disponible y se actualizan dinámicamente en función de las operaciones realizadas por los usuarios. A continuación, se explica cómo funcionan las principales características del programa:

### **1. Gestión de cuentas**
- El sistema permite configurar hasta **tres cuentas** en el menú de parámetros.
- Cada cuenta incluye: 
  - **Número de cuenta.**
  - **PIN de seguridad.**
  - **Saldo inicial.**
- Para realizar operaciones como depósitos, retiros y transferencias, es necesario validar el PIN configurado, con un límite de reintentos definido en los parámetros.

### **2. Estaciones de servicio**
El autobanco cuenta con cuatro estaciones que ofrecen los siguientes servicios:
- **Compra/venta de dólares**:
  - Permite realizar transacciones de compra y venta de dólares sin necesidad de configurar una cuenta.
  - En la compra de dólares:
    - Se calcula el total en quetzales según el tipo de cambio.
    - Se deducen billetes de las bóvedas de quetzales, priorizando denominaciones altas.
    - Se incrementa la cantidad en la bóveda de dólares.
  - En la venta de dólares:
    - Se reduce la cantidad en la bóveda de dólares.
    - Se suman billetes a las bóvedas de quetzales según el tipo de cambio.
- **Retiros**:
  - Requiere ingresar el **Número de cuenta**, el **PIN**, y el **monto**.
  - El dinero se entrega utilizando la **mayor cantidad posible de billetes** con denominaciones altas.
  - Si las bóvedas no cuentan con fondos suficientes, la transacción no se completa.
- **Depósitos**:
  - Requiere ingresar el **Número de cuenta** y el **monto a depositar**.
  - Actualiza el saldo de la cuenta y las bóvedas.
- **Transferencias**:
  - Requiere ingresar el **Número de cuenta origen**, el **PIN**, el **monto**, y el **Número de cuenta destino**.
  - Valida que la cuenta origen tenga suficiente saldo antes de realizar la operación.

### **3. Gestión de bóvedas**
Las bóvedas almacenan dinero en las siguientes denominaciones:
- **Billetes de Q50, Q10 y Q1**.
- **Bóveda de dólares** (solo acepta valores enteros).

Reglas específicas de las bóvedas:
- Los montos en bóvedas solo pueden aumentarse en múltiplos de la denominación. Por ejemplo:
  - La bóveda de Q50 puede incrementarse por Q200 o Q400, pero no por Q135.
- Todas las transacciones (retiros y depósitos) afectan el estado actual de las bóvedas.
- Las bóvedas se gestionan mediante un archivo JSON que almacena el monto total, cantidad de billetes y fecha de última actualización.

### **4. Reportes**
El programa incluye un sistema de reportes para visualizar información financiera y operativa:
- **Saldo total por bóveda**.
- **Saldo por bóveda y denominación**.
- **Saldo por cuenta**.
- **Monto de retiros por estación**.
- **Monto de depósitos por estación**.
- **Monto de dólares comprados**.
- **Monto de dólares vendidos**.

Adicionalmente, el programa registra todo el historial de transacciones en un archivo CSV con detalles como:
- Fecha y hora.
- Tipo de transacción (retiro, depósito, compra/venta de dólares, transferencia).
- Valor de la transacción.
- Bóveda afectada.

### **5. Configuración de parámetros**
Desde el menú principal, puedes acceder al menú de configuración de parámetros, donde se pueden ajustar:
- **Intentos permitidos** para validar el PIN.
- **Saldos iniciales** en cada bóveda.
- **Tipo de cambio** para compra y venta de dólares (solo acepta valores enteros).
- Configuración de cuentas (número de cuenta, PIN y saldo).

### **6. Formato de fecha y hora**
El programa muestra siempre la fecha y hora actual en el formato:
![image](https://github.com/user-attachments/assets/9898ed27-f3d8-470f-b3fa-baa034dc76ca)

## **Requisitos**
- **Plataforma:** Windows.
- **Lenguaje de programación:** C#.
- **Herramienta de desarrollo:** Visual Studio 2022 o superior.
- **Dependencias:**
  - `System.Text.Json` para manejar datos en JSON.
  - Manejo de archivos CSV para reportes de transacciones.

## **Instrucciones de uso**
1. Clona este repositorio:
   ```bash
   git clone https://github.com/angxlhndz-gt/Practica-1_AngelMoreno.git


