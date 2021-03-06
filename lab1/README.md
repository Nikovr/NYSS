# Лабораторная Работа №1 - Шифр Цезаря
Данное приложение позволяет зашифровывать сообщения, используя [Шифр Цезаря](https://ru.wikipedia.org/wiki/%D0%A8%D0%B8%D1%84%D1%80_%D0%A6%D0%B5%D0%B7%D0%B0%D1%80%D1%8F), а также их расшифровывать, вручную и автоматически. 
* Функция автоматической расшифровки нестабильна и работает только на достаточно больших текстах
## Скачать приложение
[Caesar Cipher.exe](https://github.com/Nikovr/NYSS/raw/main/lab1/Caesar%20Cipher.exe)
## Как пользоваться
```
Чтобы зашифровать сообщение, необходимо выставить шаг 0, написать или загрузить текст из файла и выставить желаемый шаг шифрования
```

```
Чтобы расшифровать сообщение:
* Если известен шаг шифрования --- выставить известный шаг, написать или загрузить текст из файла и выставить шаг 0
* Если шаг не известен --- написать или загрузить текст из файла и вручную менять шаг пока сообщение не расшифрутеся ИЛИ воспользоваться кнопкой "Попробовать расшифровать" (следует учитывать, что результат не всегда получается достоверным).
```
## Описание
### Cipher.cs
* russianAlphabet - Хранит русский алфавит в строковом представлении
* lastStep - Хранит последний шаг сдвига
* Метод Encrypt - основной метод, который сдвигает русские буквы в тексте на определенный шаг
* Метод Decrypt - вызывается только в методе Encrypt, приводит текст в его оригинальное состояние (шаг 0) путем обратного сдвига на шаг, хранящийся в lastStep. Это нужно для того, чтобы метод Encrypt возвращал результат для шага 0 + n, а не текущийШаг + n.
* Метод GuessStep - возвращает предполагаемый шаг для расшифровки полученного сообщения путем анализа самой часто встречающейся буквы в сообщении. Метод высчитывает, какой шаг нужно сделать, чтобы самая часто встречающаяся буква превратилась в букву О, поскольку это самая часто встречающаяся буква в русском алфавите.
### FileManagement.cs
* Оба метода, Save и Upload взяты прямиком из документации Microsoft и отвечают соответсвенно за сохранение сообщения в файл и за загрузки текста из файла.
### MainWindow.xaml(.cs)
* Окно, в котором мы задаем его минимальный размер и располагаем главный фрейм, в котором и будут располагаться 2 основные страницы
### Menu.xaml(.cs)
* Страница, которая автоматически помещается во фрейм при запуске приложения. Там располагаются лишь две кнопки: старт и выход. При нажатии на старт в главный фрейм помещается следующая страница
### Interface.xaml(.cs)
* Страница, на которой расположен основной пользовательский интерфейс
* Метод Return - при нажатии соответсвующей кнопки переносит программу на страницу назад, предварительно вызвав метот Encrypt, чтобы lastStep был равен нулю при повторном запуске страницы.
* Метод PreviewStepInput не позволяет пользователю вводить некорректные значения шага, используя валидатор StepIsValid
* Метод StepChanged - основа всей программы, при любом изменении шага вызывается метод Encrypt(), которому передается текущее значение шага.
* Метод DisplayLetter - отображает на странице букву, соответсвующую текущему шагу, используя алфавит из класса Cipher.
* Методы MinusStep и PlusStep - при нажатии соответсвующей кнопки или убавляют или прибавляют к текущему значению шага единицу.
* Метод TryHack - кнопка вызывает метод GuessStep, передает ему текущее сообщение и меняет шаг на результат метода.
* Методы UploadText и SaveText - при нажатии соответсвующей кнопки вызывают методы из FileManager.
* Метод TextBox_Focus - первый клик по окошку с сообщением удаляет его дефлотное содержимое ("Введите текст").
