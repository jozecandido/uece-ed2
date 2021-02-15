// ICoder.h

using System;

namespace LZMA//SevenZip
{
	// The exception that is thrown when an error in input stream occurs during decoding.
	//Exceção que é levantada quando há erro na entrda dos dados durante a decodificação
	class DataErrorException : ApplicationException
	{
		public DataErrorException(): base("Data Error") { }
	}

	// The exception that is thrown when the value of an argument is outside the allowable range.
	// Exceção que é levantada quando o valor de um argumento está fora dos limites
	class InvalidParamException : ApplicationException
	{
		public InvalidParamException(): base("Invalid Parameter") { }
	}

	public interface ICodeProgress
	{
		// Callback progress.
		// <param name="inSize">
		// input size. -1 if unknown.
		// </param>
		// <param name="outSize">
		// output size. -1 if unknown.
		// </param>
		void SetProgress(Int64 inSize, Int64 outSize);
	};

	public interface ICoder
	{
		// Codes streams.
		// <param name="inStream">
		// input Stream.
		// </param>
		// <param name="outStream">
		// output Stream.
		// </param>
		// <param name="inSize">
		// input Size. -1 if unknown.
		// </param>
		// <param name="outSize">
		// output Size. -1 if unknown.
		// </param>
		// <param name="progress">
		// callback progress reference.
		// </param>
		// <exception cref="SevenZip.DataErrorException">
		// if input stream is not valid
		// </exception>
		void Code(System.IO.Stream inStream, System.IO.Stream outStream,
			Int64 inSize, Int64 outSize, ICodeProgress progress);
	};

	/*
	public interface ICoder2
	{
		 void Code(ISequentialInStream []inStreams,
				const UInt64 []inSizes, 
				ISequentialOutStream []outStreams, 
				UInt64 []outSizes,
				ICodeProgress progress);
	};
  */

	// Provides the fields that represent properties idenitifiers for compressing.
	//Provê os campos que representam os identificadores de propriedade para compressão
	public enum CoderPropID
	{
		// Specifies size of dictionary.
		// Especifica o tamanho do dicionário
		DictionarySize = 0x400,
		// Specifies size of memory for PPM*.
		// Especifica o tamanho da memória para PPM*
		UsedMemorySize,
		// Specifies order for PPM methods.
		// Especifica a ordem para os métodos PPM
		Order,
		// Specifies number of postion state bits for LZMA (0 <= x <= 4).
		// Especifica o número de bits de estado de posição para o LZMA (0 <= x <= 4)
		PosStateBits = 0x440,
		// Specifies number of literal context bits for LZMA (0 <= x <= 8).
		// Especifica o númro de bits do contexto literal para o LZMA (0 <= x <= 8).
		LitContextBits,
		// Specifies number of literal position bits for LZMA (0 <= x <= 4).
		// Especifica o número de bists de posição literal para o LZMA (0 <= x <= 4).
		LitPosBits,
		// Specifies number of fast bytes for LZ*.
		// Especifica o número dos últimos bytes para o LZ* 
		NumFastBytes = 0x450,
		// Specifies match finder. LZMA: "BT2", "BT4" or "BT4B".
		// </summary>
		MatchFinder,
		// Specifies number of passes.
		// Especifica o número de passagens
		NumPasses = 0x460,
		// Specifies number of algorithm.
		// Especofoca o número de algoritmos
		Algorithm = 0x470,
		// Specifies multithread mode.
		// Especifica o modo multithread
		MultiThread = 0x480,
		// Specifies mode with end marker.
		// </summary>
		EndMarker = 0x490
	};


	public interface ISetCoderProperties
	{
		void SetCoderProperties(CoderPropID[] propIDs, object[] properties);
	};

	public interface IWriteCoderProperties
	{
		void WriteCoderProperties(System.IO.Stream outStream);
	}

	public interface ISetDecoderProperties
	{
		void SetDecoderProperties(byte[] properties);
	}
}
