using Puc.Molic.Model;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Puc.Molic.Test
{
    //Testing file Conversion and Object transformation
    //Author: Pedro Henrique Bof Gerico
    public class ConversionTest
    {

        //test converting object to XML
        [Fact]
        public void TestDiagramToXML()
        {
            DiagramFlow flow = new DiagramFlow();   
            var diagram = flow.GetDiagram();
            TransformationHelper transformationHelper = new TransformationHelper();
            string xml = transformationHelper.ToXML(diagram);

            Assert.False(string.IsNullOrWhiteSpace(xml));

        }

		//test converting XML to object
		[Fact]
        public void TestXMLToDiagram()
        {

			string xml = GetXML();

            Diagram diagram = TransformationHelper.LoadFromXMLString(xml);

			Assert.True(diagram.Nodes.Count > 0);

        }

        public string GetXML()
        {

			return @"<?xml version=""1.0"" encoding=""utf-16""?>
							<Diagram xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" Id=""1"" Name=""Sistema Banc�rio"" CreationDate=""2022-08-25T03:01:56.4801662+01:00"" LastSaved=""2022-08-25T03:01:56.4802+01:00"">
								<Nodes>
									<Node Id=""1"" Type=""Opening"">
										<Geometry>
											<PositionX>210</PositionX>
											<PositionY>100</PositionY>
										</Geometry>
										<Dialogs/>
										<Precond/>
									</Node>
									<Node Id=""2"" Type=""Scene"" Topic=""Identificar conta banc�ria"">
										<Geometry>
											<PositionX>210</PositionX>
											<PositionY>300</PositionY>
										</Geometry>
										<Dialogs>
											<Dialog Subject=""informar conta"">
												<Signs>
													<Sign Type=""d+u"">ag�ncia</Sign>
													<Sign Type=""d+u"">conta</Sign>
												</Signs>
											</Dialog>
											<Dialog Subject=""informar senha"">
												<Signs>
													<Sign Type=""d+u"">senha</Sign>
												</Signs>
											</Dialog>
										</Dialogs>
										<Precond/>
									</Node>
									<Node Id=""3"" Type=""SystemProcess"" Comment=""(processando identifica��o da conta banc�ria)"">
										<Geometry>
											<PositionX>210</PositionX>
											<PositionY>500</PositionY>
										</Geometry>
										<Dialogs/>
										<Precond/>
									</Node>
									<Node Id=""4"" Type=""Scene"" Comment=""Consultar produtos e servi�os para correntistas"">
										<Geometry>
											<PositionX>210</PositionX>
											<PositionY>600</PositionY>
										</Geometry>
										<Dialogs>
											<Dialog Subject=""lembrar conta"">
												<Signs>
													<Sign Type=""d"">ag�ncia</Sign>
													<Sign Type=""d"">conta</Sign>
												</Signs>
											</Dialog>
											<Dialog Subject=""ver saldo abreviado"">
												<Pressup>a maioria dos usrs consulta o saldo assim que entra na conta</Pressup>
												<Signs>
													<Sign Type=""d"">saldo</Sign>
												</Signs>
											</Dialog>
											<Dialog Subject=""ver produtos e servi�os"">
												<Signs>
													<Sign Type=""d"">seguro, c�mbio, empr�stimo, ...</Sign>
												</Signs>
											</Dialog>
										</Dialogs>
										<Precond/>
									</Node>
									<Node Id=""5"" Type=""TopicChange"">
										<Geometry>
											<PositionX>300</PositionX>
											<PositionY>500</PositionY>
										</Geometry>
										<Dialogs/>
										<Precond>
											<Conditions>
												<Condition>session.conta_identificada == True</Condition>
											</Conditions>
										</Precond>
									</Node>
									<Node Id=""6"" Type=""Scene"" Topic=""Consultar saldo"">
										<Geometry>
											<PositionX>300</PositionX>
											<PositionY>600</PositionY>
										</Geometry>
										<Dialogs>
											<Dialog Subject=""lembrar conta"" Ref=""4"">
												<Signs/>
											</Dialog>
											<Dialog Subject=""ver saldo"">
												<Signs>
													<Sign Type=""d"">saldo</Sign>
													<Sign Type=""d"">limite de cr�dito</Sign>
												</Signs>
											</Dialog>
										</Dialogs>
										<Precond/>
									</Node>
									<Node Id=""7"" Type=""Scene"" Topic=""Consultar extrato do periodo &lt;Per&gt;"">
										<Geometry>
											<PositionX>300</PositionX>
											<PositionY>600</PositionY>
										</Geometry>
										<Dialogs>
											<Dialog Subject=""lembrar conta"">
												<Signs/>
											</Dialog>
											<Dialog Subject=""informar periodo (default = Per)"">
												<Signs>
													<Sign Type=""d + u"">datas de inicio e fim</Sign>
												</Signs>
											</Dialog>
											<Dialog Subject=""ver extrato"">
												<Signs>
													<Sign Type=""d"">transacoes</Sign>
												</Signs>
											</Dialog>
										</Dialogs>
										<Precond/>
									</Node>
									<Node Id=""8"" Type=""Scene"" Topic=""Modificar periodo do extrato"">
										<Geometry>
											<PositionX>300</PositionX>
											<PositionY>600</PositionY>
										</Geometry>
										<Dialogs>
											<Dialog Subject=""lembrar conta"">
												<Signs/>
											</Dialog>
											<Dialog Subject=""informar periodo"">
												<Signs>
													<Sign Type=""d + u"">datas de inicio e fim</Sign>
													<Sign Type=""d + u"">ultimos N dias</Sign>
													<Sign Type=""d + u"">ultimas N transacoes</Sign>
												</Signs>
											</Dialog>
											<Dialog Subject=""configurar periodo default"">
												<Signs>
													<Sign Type=""d+u"">modificar default (sim/nao)</Sign>
												</Signs>
											</Dialog>
										</Dialogs>
										<Precond/>
									</Node>
									<Node Id=""9"" Type=""SystemProcess"" Comment=""(processando modificacao do periodo)"">
										<Geometry>
											<PositionX>210</PositionX>
											<PositionY>500</PositionY>
										</Geometry>
										<Dialogs/>
										<Precond/>
									</Node>
								</Nodes>
								<Edges>
									<Edge Id=""1"" Type=""TurnGiving"" SourceId=""1"" TargetId=""2"">
										<Utterance Issuer=""u"">sistema do banco</Utterance>
										<Precond/>
										<Effect>
											<Variables/>
										</Effect>
									</Edge>
									<Edge Id=""2"" Type=""TurnGiving"" SourceId=""2"" TargetId=""3"">
										<Utterance Issuer=""u"">identificar conta</Utterance>
										<Precond/>
										<Effect>
											<Variables/>
										</Effect>
									</Edge>
									<Edge Id=""3"" Type=""BreakdownRecovery"" SourceId=""3"" TargetId=""2"">
										<Utterance Issuer=""d"">ag�ncia, conta ou senha inv�lida</Utterance>
										<Precond/>
										<Effect>
											<Variables/>
										</Effect>
									</Edge>
									<Edge Id=""4"" Type=""TurnGiving"" SourceId=""3"" TargetId=""4"">
										<Utterance/>
										<Precond>
											<Conditions>
												<Condition>o banco lucra muito com produtos e servi�os</Condition>
											</Conditions>
										</Precond>
										<Effect>
											<Variables>
												<Variable Name=""conta_identificada"" Type=""boolean"" Scope=""session"">true</Variable>
											</Variables>
										</Effect>
									</Edge>
									<Edge Id=""5"" Type=""TurnGiving"" SourceId=""5"" TargetId=""6"">
										<Utterance Issuer=""u"">consultar saldo</Utterance>
										<Precond/>
										<Effect>
											<Variables/>
										</Effect>
									</Edge>
									<Edge Id=""6"" Type=""TurnGiving"" SourceId=""4"" TargetId=""5"">
										<Utterance Issuer=""u"">consultar produtos e servi�os</Utterance>
										<Precond/>
										<Effect>
											<Variables/>
										</Effect>
									</Edge>
									<Edge Id=""7"" Type=""TurnGiving"" SourceId=""5"" TargetId=""7"">
										<Utterance Issuer=""u"">consultar extrato pressup: a maioria dos usrs consulta a ultima semana (Per = conta.periodo OR ultimos 7 dias)</Utterance>
										<Precond/>
										<Effect>
											<Variables/>
										</Effect>
									</Edge>
									<Edge Id=""8"" Type=""TurnGiving"" SourceId=""6"" TargetId=""7"">
										<Utterance Issuer=""u"">consultar extrato</Utterance>
										<Precond/>
										<Pressup>qualquer surpresa no saldo leva o usr a consultar o extrato</Pressup>
										<Effect>
											<Variables/>
										</Effect>
									</Edge>
									<Edge Id=""9"" Type=""TurnGiving"" SourceId=""7"" TargetId=""8"">
										<Utterance Issuer=""u"">modificar periodo</Utterance>
										<Precond/>
										<Effect>
											<Variables/>
										</Effect>
									</Edge>
									<Edge Id=""10"" Type=""BreakdownRecovery"" SourceId=""8"" TargetId=""7"">
										<Utterance Issuer=""u"">cancelar</Utterance>
										<Precond/>
										<Effect>
											<Variables/>
										</Effect>
									</Edge>
									<Edge Id=""11"" Type=""TurnGiving"" SourceId=""8"" TargetId=""9"">
										<Utterance Issuer=""u"">Efetivar Per como novo periodo</Utterance>
										<Precond/>
										<Effect>
											<Variables/>
										</Effect>
									</Edge>
									<Edge Id=""12"" Type=""TurnGiving"" SourceId=""9"" TargetId=""7"">
										<Utterance/>
										<Precond>
											<Conditions>
												<Condition>modificar default == sim</Condition>
												<Condition>modificar default == nao</Condition>
											</Conditions>
										</Precond>
										<Effect>
											<Variables>
												<Variable Name=""conta_periodo"">Per</Variable>
											</Variables>
										</Effect>
									</Edge>
									<Edge Id=""13"" Type=""BreakdownRecovery"" SourceId=""9"" TargetId=""8"">
										<Utterance Issuer=""d"">data inicio posterior a data fim</Utterance>
										<Precond/>
										<Effect>
											<Variables/>
										</Effect>
									</Edge>
								</Edges>
							</Diagram>";


		}


    }
}