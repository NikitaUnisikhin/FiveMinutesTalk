// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Перенес сюда подключение кнопки добавления к функции, т.к. писать onclick в html плохая практика
let addQuestion = document.querySelector('#add');
addQuestion.addEventListener('click', newField);

// Я предлагаю сделать глобальный id для вопросов, чтобы после удаления у нас не было совпадений id вопросов
let questionId = 1;

function newField() {
    // определяем контейнер для хранения полей с вопросами
    let container = document.getElementById("questions");
    // получаем текущее количество input (полей для вопросов)
    let fieldCount = container.getElementsByTagName("input").length;
    // увеличиваем No для нового поля
    let nextFieldNo = fieldCount + 1;

    // здесь добавляем элемент, который будет хранить input
    let div = document.createElement("div");
    div.setAttribute("class", "form-group");
    
    
    // создаем новое поле с новым id, name ДОЛЖЕН СОВПАДАТЬ С ИМЕНЕМ ПОЛЯ В МОДЕЛИ!!!
    let field = document.createElement("input");
    field.setAttribute("class", "form-control");
    field.setAttribute("id", "Questions[" + questionId++ + "]");
    field.setAttribute("name", "Questions");
    field.setAttribute("type", "text");
    field.setAttribute("placeholder", "Введите текст вопроса");

    // а здесь я своими кривыми ручками создаю номера вопросов
    const questionNumber = document.createTextNode(nextFieldNo + " ");
    div.appendChild(questionNumber);
    
    // Здесь создаем выбор типа вопроса
    let lbl = document.createElement("label");
    let spn = document.createElement("span");
    spn.textContent = "Тип вопроса: ";
    let questionType = document.createElement("select");
    
    questionType.options[0] = new Option("Текст", "Текст");
    questionType.options[1] = new Option("Код", "Код");
    questionType.options[2] = new Option("Один из списка", "Один из списка");
    questionType.options[3] = new Option("Несколько из списка", "Несколько из списка");
    
    lbl.appendChild(spn);
    lbl.appendChild(questionType);
    
    // добавляем всё это в div
    div.appendChild(lbl);

    // Здесь создаю кнопку для удаления вопроса
    let close = document.createElement("button");
    close.setAttribute("class", "close-button");
    close.addEventListener('click', removeParnet);
    close.textContent = "X";
    div.appendChild(close);
    
    // добавляем поле в <div class="form-group"></div>
    div.appendChild(field);
    // добавляем <div class="form-group"><input ... /></div> в главный контейнер
    container.appendChild(div);
}

function removeParnet(){
    let revDiv = this.parentElement;
    revDiv.remove();
}