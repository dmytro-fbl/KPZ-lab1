## Дотримання принципів програмування 


### 1. Принцип (Single Responsibility Principle) він відноситься до даних файлів:  

[Product](https://github.com/dmytro-fbl/KPZ-lab1/blob/master/SimpleClassLibrary/Product.cs) - Зберігає дані та стежить за їхньою правильністю,

[Currency](https://github.com/dmytro-fbl/KPZ-lab1/blob/master/SimpleClassLibrary/Currency.cs) - Зберігає дані та стежить за їхньою правильністю,

[Record](https://github.com/dmytro-fbl/KPZ-lab1/blob/master/SimpleClassConlsole/Record.cs) - малює меню і виводить текст у консоль (тільки UI),

[InputValidator](https://github.com/dmytro-fbl/KPZ-lab1/blob/master/SimpleClassConlsole/InputValidator.cs) - бере на себе весь процес спілкування з користувачем під час вводу,

[Program](https://github.com/dmytro-fbl/KPZ-lab1/blob/master/SimpleClassConlsole/Program.cs) - просто керує процесом.

### 2. Принцип Don't Repeat Yourself (DRY)

У класі [InputValidator](https://github.com/dmytro-fbl/KPZ-lab1/blob/master/SimpleClassConlsole/InputValidator.cs#L12-L50) - Використав метод і перевантажив його щоб уникнути дублювання коду для однакової умови перевірки даних.

### 3. Інкапсуляція 

Переписав класи так щоб приховати внутрішній стан об'єктів і надав доступ тільки через безпечний спосіб 

(замінив методи на властивості) 
[Currency.cs](https://github.com/dmytro-fbl/KPZ-lab1/blob/master/SimpleClassLibrary/Currency.cs), [Product.cs](https://github.com/dmytro-fbl/KPZ-lab1/blob/master/SimpleClassLibrary/Product.cs)
