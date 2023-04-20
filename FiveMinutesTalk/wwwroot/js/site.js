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
    field.setAttribute("id", "Questions[" + questionId + "]");
    field.setAttribute("name", "Questions");
    field.setAttribute("type", "text");
    field.setAttribute("placeholder", "Введите текст вопроса");

    // а здесь я своими кривыми ручками создаю номера вопросов
    const questionNumber = document.createTextNode(String(nextFieldNo));
    div.appendChild(questionNumber);
    
    // Здесь создаем выбор типа вопроса
    let lbl = document.createElement("label");
    let spn = document.createElement("span");
    spn.textContent = "Тип вопроса: ";
    let questionType = document.createElement("select");
    questionType.id = String(questionId);
    
    // Я посмотрел, что это неправильный вариант записи, но он мне больше понравился благодаря своей краткости и понятности
    questionType.options[0] = new Option("Текст", "Текст");
    questionType.options[1] = new Option("Код", "Код");
    questionType.options[2] = new Option("Один из списка", "Один из списка");
    questionType.options[3] = new Option("Несколько из списка", "Несколько из списка");
    
    // При изменении типа будем менять компонеты вопроса
    questionType.addEventListener('change', function(questionType) {
        changeComponents(questionType)
    });
    
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
    
    // Поле для ответа(здесь будут варианты выбора ответа и т.д.)
    let div2 = document.createElement("div");
    div.appendChild(div2);
    
    // добавляем <div class="form-group"><input ... /></div> в главный контейнер
    container.appendChild(div);
    
    // Если удачно всё выполнилось до этого и создался новый вопрос, инкрементируем
    questionId++;
}

function removeParnet(){
    let revDiv = this.parentElement;
    revDiv.remove();
}

// Функция в зависимости от выбранного типа будет менять варианты ответа под вопросом
function changeComponents(questionType){
    // Получаем элемент на котором произошло событие
    let questType = questionType.currentTarget;
    let selectedValue = questType.value;
    // здесь, зная id, мы получаем контейнер с вопросом(в дальнейшем я изменю этот костыль)
    let cont = document.getElementById("Questions[" + questType.id + "]");
    let nextDiv = cont.nextSibling;
    nextDiv.remove();
    let newDiv = document.createElement("div");
    
    if (selectedValue === "Текст"){
        newDiv.innerText = "Текст";
    } else if (selectedValue === "Код"){
        newDiv.innerText = "Код";
    } else if (selectedValue === "Один из списка"){
        newDiv.innerText = "Один из списка";
    } else if (selectedValue === "Несколько из списка"){
        newDiv.innerText = "Несколько из списка";
    }
    cont.after(newDiv);
}