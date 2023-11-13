# TelegramKinoBot-AdminPanel


## О проекте

TelegramKinoBot-AdminPanel - это административная панель для управления [TelegramKinoBot](https://github.com/Vaisero/TelegramKinoBot) - [❤️🎬Кино Коды🎬❤️](https://t.me/kinokodi_bot) - бота для поиска "искомых" фильмов.

## Особенности

* Управление и модификация данных для TelegramBot
* Добавление, редактирование и удаление фильмов, постеров, ссылок
* Возможность просмотра текущик источников данных
* Интерфейс со всеми необходимыми функциями
* Возможность сменить пользователя на администратора - для расширенного использования (в разработке)

## Как использовать:

0. Создайте базу данных в PostgreSQL, описание которой приведено ниже
1. Запустите .exe приложение
2. Сверху, на панели инструментов, выберете пункт "Добавить"
3. Заполните данные о фильме в таблицу (первые три строки - обязательные)
4. Убедитесь, что данные заполнены верно и нажмите кнопку "Сохранить"
5. Добавленный фильм появится с списке и отобразится его постер
6. Запустите [TelegramKinoBot](https://github.com/Vaisero/TelegramKinoBot) и введите id вашего фильма
7. При ошибочных данных - редактируйте запись или удалите фильм без потери id
8. Смените пользователя на администратора для получения расширенных прав пользования (в разработке)



## Интерфейс
![1](https://i122.fastpic.org/big/2023/1113/f0/e86e49ea10d6613eeee4db1d439a54f0.png?md5=zAge_TA_r7E13Vfz5TP10w&expires=1699909200)

![2](https://i122.fastpic.org/big/2023/1113/2b/8fa578d11e7265b96b37d016ca438a2b.png?md5=lUE3qgBMjpyYBLJMI2_fIQ&expires=1699909200)

![3](https://i122.fastpic.org/big/2023/1113/56/b32fc15d755e834bbca44ea13715fa56.png?md5=gTTaLlThbco6fCZ29IBqVQ&expires=1699909200)



## Состав базы данных:

*kino.kino*
* id (bigint) - уникальный идентификатор для каждого фильма с помощью которого и производится поиск по базе данных 
* name (text) - название фильма
* image (text) - постер фильма, представленный в виде ссылки на изображение
* kino_link (text) - ссылка на ресурс [Кинопоиск](https://www.kinopoisk.ru/) для ознакомления с описанием фильма
* link1, link2, link3, link4 (text) - ссылки на сторонние ресурсы для просмотра фильма онлайн без рекламы

  `
    CREATE TABLE IF NOT EXISTS kino.kino(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    name text COLLATE pg_catalog."default" NOT NULL,
    image text COLLATE pg_catalog."default" NOT NULL,
    kino_link text COLLATE pg_catalog."default" NOT NULL,
    link1 text COLLATE pg_catalog."default" default NULL,
    link2 text COLLATE pg_catalog."default" default NULL,
    link3 text COLLATE pg_catalog."default" default NULL,
    link4 text COLLATE pg_catalog."default" default NULL,
    CONSTRAINT kino_pkey PRIMARY KEY (id))
  `

## Технологии

* Проект написан на .NET Framework 4.8 с использованием языка программирования C# и библиотеки WindowsForms
* Для работы с базой данных используется PostgreSQL, которая является надежной и мощной системой управления реляционными базами данных
* Код разделен на модули и классы согласно принципам объектно-ориентированного программирования, что обеспечивает его читаемость, масштабируемость и возможность повторного использования
* В проекте используются инструменты для валидации пользовательского ввода, обработки и вывода данных, обеспечивая безопасность и удобство использования

## Задача проекта - облегчить рутинные задачи в работе с данными для [TelegramKinoBot](https://github.com/Vaisero/TelegramKinoBot) - [❤️🎬Кино Коды🎬❤️](https://t.me/kinokodi_bot)

