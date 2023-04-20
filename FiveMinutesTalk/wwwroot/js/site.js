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
    spn.textContent = "Тип вопроса:";
    let questionType = document.createElement("select");
    
    let opt1 = document.createElement("option");
    opt1.setAttribute("value", "Текст");
    let nod1 = document.createTextNode("Текст");
    opt1.appendChild(nod1);

    let opt2 = document.createElement("option");
    opt2.setAttribute("value", "Код");
    let nod2 = document.createTextNode("Код");
    opt2.appendChild(nod2);

    let opt3 = document.createElement("option");
    opt3.setAttribute("value", "Один из списка");
    let nod3 = document.createTextNode("Один из списка");
    opt3.appendChild(nod3);

    let opt4 = document.createElement("option");
    opt4.setAttribute("value", "Несколько из списка");
    let nod4 = document.createTextNode("Несколько из списка");
    opt4.appendChild(nod4);

    questionType.appendChild(opt1);
    questionType.appendChild(opt2);
    questionType.appendChild(opt3);
    questionType.appendChild(opt4);
    
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