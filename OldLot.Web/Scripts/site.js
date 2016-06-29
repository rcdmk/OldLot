// depende de jQuery 1.7+

$(function () {
	var $body = $("body");

	$body.append('<div id="dialogoModal" class="modal fade" tabindex="1" role="dialog">'
                   + '<div class="modal-dialog">'
                        + '<div class="modal-content">'
                            + '<div class="modal-header">'
                                + '<button type="button" class="close" data-dismiss="modal" aria-label="Fechar"><span aria-hidden="true" class="glyphicon glyphicon-remove"></span></button>'
                                + '<h4 class="modal-title">&nbsp;</h4>'
                            + '</div>'
                            + '<div class="modal-body">&nbsp;</div>'
                            + '<div class="modal-footer">'
                                + '<button type="button" id="btnCancelar" class="btn btn-default" data-dismiss="modal">Cancelar</button>'
                                + '<a href="#" id="btnOK" class="btn btn-danger" data-dismiss="modal">OK</button>'
                            + '</div>'
                        + '</div>'
                    + '</div>'
                + '</div>');

	var dialogo = $("#dialogoModal");
	var conteudoDialogo = $(".modal-body", dialogo);
	var tituloDialogo = $(".modal-title", dialogo);
	var botoesDialogo = $(".modal-footer", dialogo);

	dialogo.modal({
		show: false
	});

	dialogo.on("click", "#btnCancelar", function (e) {
		var callback = dialogo.data("callbackCancelar");

		if (typeof callback == "function") callback(e);
	});

	dialogo.on("click", "#btnOK", function (e) {
		var callback = dialogo.data("callbackOK");

		if (typeof callback == "function") callback(e);
	});

	function carregarModal(url, callbackOk, callbackErro) {
		$body.addClass("loading");
		conteudoDialogo.html("");
		dialogo.find("button").show();
		botoesDialogo.hide();

		$.ajax({
			url: url + "?parcial=s",
			cache: false,
			success: function (data) {
				conteudoDialogo.html(data);

				var titulo = conteudoDialogo.find("h4");
				tituloDialogo.text(titulo.text());
				titulo.remove();

				if (typeof callbackOk === "function") callbackOk(data);

				dialogo.modal("show");
			},
			error: function (xhr, status, message) {
				conteudoDialogo.text("Houve um problema ao obter o conteúdo: " + message);

				if (typeof callbackErro === "function") callbackErro(xhr, status, message);

				dialogo.modal("show");
			},
			complete: function () {
				$body.removeClass("loading");
			}
		});
	}

	function perguntaModal(pergunta, callbackOK, callbackCancelar) {
		dialogo.data("callbackOK", callbackOK);
		dialogo.data("callbackCancelar", callbackCancelar);

		tituloDialogo.html("Confirmação");
		conteudoDialogo.html(pergunta);
		botoesDialogo.show();

		dialogo.modal("show");
	}

	$(".visualizar").on("click", function (e) {
		e.preventDefault();

		var url = $(this).attr("href");

		carregarModal(url);
	});

	$(".excluir").on("click", function (e) {
		e.preventDefault();

		var $this = $(this);

		var url = $this.attr("href");
		var pergunta = $this.data("confirm") || "Tem certeza que deseja continuar?";

		perguntaModal(pergunta, function (e) {
			window.location.href = url;
		});
	});
});
