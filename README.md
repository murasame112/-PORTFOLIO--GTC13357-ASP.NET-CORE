# GTC13357

Projekt strony do zarządzania sklepem z kursami w ASP.NET CORE

1:
Dość ważna uwaga - w kodzie, Course odpowiada tak naprawdę Uczestnikom kursów, a CourseTitle odpowiada Kursom.
Stało się to dlatego, że mój plan na ten projekt lekko ewoluuował z każdymi kolejnymi laboratoriami - poznawanie nowych rzeczy sprawiało, że zmieniałem wcześniej zaplanowany projekt
Finalnie, encja Course zaczeła odpowiadać po prostu osobom, które biorą w kursach udział. Niemniej - we frontendzie wszystko jest pod tym względem w porządku; kursy to kursy a uczestnicy to uczestnicy :)

2:
W wymaganiach nie było, że projekt automatycznie ma tworzyć jakieś rekordy w bazie danych, więc ich nie tworzy - łatwo dodać je za pośrednictwem strony, a chciałem uniknąć potencjalnych błędów

3:
Proszę najpierw dodawać rekordy Course Types, ponieważ jest to tabela podrzędna Course Title (podczas tworzenia rekordu Course Title jest wymagane podanie Id jednego z rekordów z Course Type)

4:
Akcja Attach służy do powiązania rekordów Course i Course Title (będących w relacji wiele-do-wielu)
