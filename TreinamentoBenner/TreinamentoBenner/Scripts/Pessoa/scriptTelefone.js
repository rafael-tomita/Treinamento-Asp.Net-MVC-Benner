function ScriptTelefone(idPessoa, urls) {
    // urls = adicionar, remover, listar

    var dialog = $("#dialogTelefone");
    var campoId = $("#TelefoneId");
    var campoNumero = $("#Numero");
    var tab = $("#tab-telefone");
    var form = $("form", dialog);

    this.abrirDialog = function() {
        dialog.dialog("open");
    };

    function fecharDialog() {
        campoId.val("0");
        campoNumero.val("");

        dialog.dialog("close");
    }

    function atualizar() {
        tab.load(urls.listar);
    }

    function adicionar() {
        if (!form.valid()) return;

        $.post(urls.adicionar, {
            id: campoId.val(),
            numero: campoNumero.val(),
            idPessoa: idPessoa
        }, function(data) {
            if (data.Status) {
                atualizar();
                fecharDialog();
            }

            if (data.Message) {
                alert(data.Message);
            }
        });
    }

    this.excluir = function(id) {
        if (confirm("Você tem certeza que deseja excluir?")) {
            $.post(urls.remover, { id: id }, function(data) {
                atualizar();

                if (data.Message) {
                    alert(data.Message);
                }
            });
        }
    };

    this.alterar = function(id, numero) {
        campoId.val(id);
        campoNumero.val(numero);
        this.abrirDialog();
    };

    this.iniciar = function () {
        dialog.dialog({
            title: "Adicionar Telefone",
            autoOpen: false,
            resizable: false,
            modal: true,
            buttons: {
                "Salvar": adicionar,
                "Fechar": fecharDialog
            },
            close: function() {
                form.validate().resetForm();
            }
        });

        form.submit(function($event) {
            adicionar();
            $event.preventDefault();
        });
    };
}
