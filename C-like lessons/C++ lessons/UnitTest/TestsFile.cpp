#include "pch.h"
#include "CppUnitTest.h"
#include "..\Lesson\Lesson.cpp"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnitTest
{
	TEST_CLASS(UnitTest)
	{
	public:
		
		TEST_METHOD(CallingWithOneArgument)
		{
			Assert::AreEqual(Increment(2), 3);
		}
		TEST_METHOD(CallingWithTwoArguments)
		{
			Assert::AreEqual(Increment(2, 2), 4);
		}
	};
}
