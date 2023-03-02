# University book shop

Написать end2end application, которое занимается продажей книг университетам, состоящих из нескольких кафедр.

### Архитектура приложения:
- Frontend - React и использовать: 
    - hooks
    - function component
- Backend - .net6, в котором должна быть написана вся бизнес логика. 
   - public api.Cors - почитать
- Приложение должно поддерживать переключение между двумя модами: 
  - back office - доступен только для внутреннего использования. Функционал приложения:
    - CRUD операции управления книгами. Книги должны содержать информацию:
        - isbn
        - автор
        - name
        - cost в $ 
    - Книги должны храниться в no-sql базе вроде в dynamoDB.
  - client mode - это приложение обеспечивает возможность покупки книг университетам. Функционал приложения:
    - Отобразить список клиентов т.е университетов:
      - название универа
      - описание универа
      - добавить / удалить университет. ** А изменить?**
      - Отобразить общую стоимость купленных книг **Отображать для всего университета или для факультета? Вроде говорили для университета**
    - Отобразить список книг **Купленных или общий?**:
        - развернуть / либо в новом окне
    - Отобразить название кафедр. Книги купленные этим универом можно:
        - удалять / добавлять список 
        - открыть каждый отдельный факультет
        - добавить книжку т.е купить
        - отобразить книжки которыми владеет **Факультет?**
        - отдельный бар с книгами которые можно купить 
            - купить книгу 
            - реализовать поиск книг, но если книга куплена, то это должно быть это видно
    - Доступом к книге обладает весь университет
        - **Нужно ли делать возможность передать ее другому факультету?**
    - БД должна поддерживать аврору, которая владеет информацией о:
        - универы 
        - кафедры
        - книги, структура должна быть совместима с no-sql, к которой ходим через отдельный api

*clietn side rendering(делается через s3bucket.statick side rendering)*

*code first*
## Описание инфраструктуры Aws:
 - es2
 - aws lambda
 - sns(message broker)
 - sqs(message broker)
 - IAM
 - dynamoDB -
 - Rds(aurora)
 - s3 Bucket
 - cloud formation - поднимать все выше перечисленное
 - vps
# pipelin-ы: 
- после пуша image, нужно получить изменения и запустить их на es2

    для этого нужно разобраться в и использовать:
    - action
    - esr - для докера 
    - aws github action plugin и configure - aws - credentials

- на любую операцию с книгами в dynamoDb нужно:
    1. 1. послать notification в sns. 
       2. выполнить push в sqs q 
       3. тригерить лямбду функцию, которая эту книжку обновляет в авроре
    2. 1. на sns также подписана еще одна sqs q 
       2. которая пушит текстовый лог файл 
       3. лямбда => и трансформирует в текстовый файл который должен содержать:
            - isbn 
            - тип Action, если были изменения, то указываем какие.
            - текстовый файл записывается в s3bucket
- лямды функии на ноде имеет свой pipeline