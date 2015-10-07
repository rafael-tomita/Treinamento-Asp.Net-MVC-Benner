function ScriptCidade(ufs, idCidade, urlCidade) {
    this.iniciar = function() {
        $("#" + ufs).change(function () {
            var uf = $(this).val();
            $.post(urlCidade, { uf: uf }, function(options) {
                $("#" + idCidade).html(options);
            });
        });
    };
}
