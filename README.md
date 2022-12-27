# Ведение групп

## Цель зазработки и назначение приложения 
**Цель разработки:** приложение является создание удобной системы с
организация,
предоставляющая
деятельность, сможет быстро формировать и вести списки детей (группы) за
счёт структурирования информации.

**Назначение:** формирования и ведения
списков, детей занимающихся внеурочной деятельностью.

## Принципы работы приложения
* **Работа с файлами:** для храниения всех данных приложение использует файлы, нахлдящие в папке где расположено приложение.
* **Все функции в одном окне:** все функции приложения находяться на главном окно, кототорое вызывает другие вспомогательные окна для каждой функции.
* **Работа в двух режимах:** большинство функций для работы с группами и детьми в группе схожи, поэтому приложение работае в двук режимах: работа с группами и работа внутри группы. При смене режима работы, кнопки переключаются на текущий режим работы. Смена режима происходит при использовании кноки "Просмотреть/Назад"

## Функциональные требования
* добавление группы;
* удаление группы;
* изменение значений атрибутов группы;
* добавление ребёнка в группу;
* удаление ребёнка из группы;
* изменение значений атрибутов ребёнка в группе;
* перемещение ребёнка в другую группу;

## Диаграммы
**Диаграмма вариантов использования**

![avatar](/Pictures/use_case_diagram.png)

**Диаграмма классов**

![avatar](/Pictures/class_diagram.png)


**Диаграмма компонентов**

![avatar](/Pictures/component_diagram.png)

**Диаграмма последовательности действий**

![avatar](/Pictures/sequence_of_actions_diagram.png)

## Макеты приложения
**Макет главного окна**

![avatar](/Pictures/Макет_основного_окна.png)

**Макет окна для добавления группы**

![avatar](/Pictures/Макет_создания_и_изменение_данных_группы.png)

**Макет окна для добавлния ребёнка вгруппу**

![avatar](/Pictures/Макет_окна_для_добавления_и_изменение_данных_ребёнка.png)

## Установка
1. Для уснановки приложения скачайте папку с проектом как показано на скриншоте.
![avatar](/Pictures/How_to_download_project.png)

2. После распакайте проект и в любую удобную для вас папку.
3. Откройте проект в среде разработки Microsoft Visual Studio.

Если у вас нет данной среды разработки или появилисть иные трудности октройте документ **руководство пользователя**, ссылка на которое нахлдиться ниже в разделе **"Докумнтация"**

## Документация 
**Пользовательская документация:**
* [Руководство пользователя](https://github.com/N1KF0X/Group_Management/raw/master/Documentations/User's_guide.docx)

**Документация разработки:**
* [Техническое задание](https://github.com/N1KF0X/Group_Management/raw/master/Documentations/ТЗ.docx)
* [Спецификация](https://github.com/N1KF0X/Group_Management/raw/master/Documentations/Спецификация.docx)
* [Функциональные требования](https://github.com/N1KF0X/Group_Management/raw/master/Documentations/Функциональные_требования.docx)
* [Преценденты](https://github.com/N1KF0X/Group_Management/raw/master/Documentations/Преценденты.docx)

**Документация тестирование:**
* [Тестовые пути и тестовый граф программы](https://github.com/N1KF0X/Group_Management/raw/master/Documentations/Тестовые_пути.docx)
* [Тест-кейсы](https://github.com/N1KF0X/Group_Management/raw/master/Documentations/Тест-кейсы.docx)
* [Unit тестирование](https://github.com/N1KF0X/Group_Management/raw/master/Documentations/Отчёт_о_тестировании.docx)