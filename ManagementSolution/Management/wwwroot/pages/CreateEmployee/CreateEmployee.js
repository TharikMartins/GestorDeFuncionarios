$(document).ready(function () {

    //Adicionando mascara para os inputs
    $("#Birthdate").mask("99/99/9999");
    $("#CPF").mask("999.999.999-99");
    $("#Phone").mask("(00) 0000-00009");

    //Escondendo div de dependentes
    $('#dependent_list').css("display", "none");


    //Adicionando div do dependente.
    $('#add_dependent').click(function () {

        var dependentList = $('#dependent_list').children().length;
        var count = dependentList + 1;
        var div = '<div class="dependent" id="dependent_' + count + '">' +
            '<div class="form-group">' +
            '<label class="control-label">' + 'Nome do dependente ' + count + '</label>' +
            '<input class ="form-control" id="dependent_name' + count + '" type="text"></input>' +
            '</div>' +

            '<div class="form-group">' +
            '<label class="control-label">' + 'Data de nascimento do dependente ' + count + '</label>' +
            '<input class ="form-control Birth_Dependent" id="dependent_birthdate' + count + '" type="text" value maxlength="10"></input>' +
            '</div>' +

            '<div class="form-group">' +
            '<label class="control-label" style="margin-left:6px;">' + 'Genêro do dependente ' + count + '</label> <br>' +
            '<input id="dependent_gender' + count + '" name="dependent_gender' + count + '" type="radio" value="M" style="margin-left=6px;"></input>' +
            '<label style="margin-left:6px;">Masculino</label>' +
            '<input style="margin-left:6px;" id="dependent_gender' + count + '" name="dependent_gender' + count + '" type="radio" value="F"></input>' +
            '<label style="margin-left:6px;">Feminino</label>' +
            '</div>' +

            '<div class="form-group">' +
            '<input type="button" class="btn btn-danger btn-sm remove_dependent" id="' + count + '" value="Remover dependente"></input>' +
            '</div>' +

            '</div>';

        $('#dependent_list').append(div);
        $(".Birth_Dependent").mask("99/99/9999");

        addDependentListStyle();

    });

    //Submit do formulário
    $('#send').submit(function (e) {

        e.preventDefault();
        var form = $(this);
        var data = parseForm(form);

        if (!validate_fields(data))
            return false;


        var dependentCount = $('#dependent_list').children().length;
        if (dependentCount > 0) {
            data.Dependent = getDependentsForm();
        }

        $.ajax({
            type: 'post',
            url: '/Employee/Create',
            data: data,
            success: function (response) {
                if (response.success === true) {
                    window.location.href = "/Employee";
                } else {
                    alert("Ocorreu um erro na operação, por favor tente novamente!");
                }
            }
        });

    });

    //Fazendo o parse do formulário
    function parseForm(form) {
        var config = {};
        jQuery(form).serializeArray().map(function (item) {
            if (config[item.name]) {
                if (typeof (config[item.name]) === "string") {
                    config[item.name] = [config[item.name]];
                }
                config[item.name].push(item.value);
            } else {
                config[item.name] = item.value;
            }
        });

        return config;
    }

    //Fazendo o parse dos dependentes da tela.
    function getDependentsForm() {
        var dependents = [];
        var dependentCount = $('#dependent_list').children().length;

        if (dependentCount > 0) {

            for (var i = 1; i <= dependentCount; i++) {
                var dependent = {};
                dependent.Name = $('#dependent_name' + dependentCount).val();
                dependent.Birthdate = $('#dependent_birthdate' + dependentCount).val();
                dependent.Gender = $('input[name*="dependent_gender' + dependentCount + '"]:checked').val();
                dependents.push(dependent);
            }
        }

        return dependents;
    }

    //Adicionando style da div do dependente
    function addDependentListStyle() {
        $('#dependent_list').css("display", "block");
        $('#dependent_list').css("border", "3px solid green");
        $('#dependent_list').css("padding", "15px");
        $('#dependent_list').css("margin-bottom", "10px");
    }

    //Removendo style da div do dependente
    function removeDependentListStyle() {
        $('#dependent_list').removeAttr("style");
        $('#dependent_list').css("display", "none");
    }


    //Removendo div de dependente.
    $(document).on("click", ".remove_dependent", function (event) {
        $('#dependent_' + event.target.id).remove();

        var dependentCount = $('#dependent_list').children().length;
        if (dependentCount === 0) {
            removeDependentListStyle();
        }

    });

    //Validando fields
    function validate_fields(data) {
        if (data.Address === "" || data.AddressNumber === "" || data.Birthdate === "" || data.CPF === "" || data.Name === "" || data.Phone === "")
            return false;

        return true;
    }

});