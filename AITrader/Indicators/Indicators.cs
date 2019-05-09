using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicators
{
    public class Indicators : IndicatorsBase
    {
        //public static RetCode Sar(int startIdx, int endIdx, double[] inHigh, double[] inLow, double optInAcceleration, double optInMaximum, ref int outBegIdx, ref int outNBElement, double[] outReal)
        //{
        //    double sar;
        //    double ep;
        //    int isLong;
        //    int tempInt = 0;
        //    double[] ep_temp = new double[1];
        //    if (startIdx < 0)
        //    {
        //        return RetCode.OutOfRangeStartIndex;
        //    }
        //    if ((endIdx < 0) || (endIdx < startIdx))
        //    {
        //        return RetCode.OutOfRangeEndIndex;
        //    }
        //    if ((inHigh == null) || (inLow == null))
        //    {
        //        return RetCode.BadParam;
        //    }
        //    if (optInAcceleration == -4E+37)
        //    {
        //        optInAcceleration = 0.02;
        //    }
        //    else if ((optInAcceleration < 0.0) || (optInAcceleration > 3E+37))
        //    {
        //        return RetCode.BadParam;
        //    }
        //    if (optInMaximum == -4E+37)
        //    {
        //        optInMaximum = 0.2;
        //    }
        //    else if ((optInMaximum < 0.0) || (optInMaximum > 3E+37))
        //    {
        //        return RetCode.BadParam;
        //    }
        //    if (outReal == null)
        //    {
        //        return RetCode.BadParam;
        //    }
        //    if (startIdx < 1)
        //    {
        //        startIdx = 1;
        //    }
        //    if (startIdx > endIdx)
        //    {
        //        outBegIdx = 0;
        //        outNBElement = 0;
        //        return RetCode.Success;
        //    }
        //    double af = optInAcceleration;
        //    if (af > optInMaximum)
        //    {
        //        optInAcceleration = optInMaximum;
        //        af = optInAcceleration;
        //    }
        //    RetCode retCode = MinusDM(startIdx, startIdx, inHigh, inLow, 1, ref tempInt, ref tempInt, ep_temp);
        //    if (ep_temp[0] > 0.0)
        //    {
        //        isLong = 0;
        //    }
        //    else
        //    {
        //        isLong = 1;
        //    }
        //    if (retCode != RetCode.Success)
        //    {
        //        outBegIdx = 0;
        //        outNBElement = 0;
        //        return retCode;
        //    }
        //    outBegIdx = startIdx;
        //    int outIdx = 0;
        //    int todayIdx = startIdx;
        //    double newHigh = inHigh[todayIdx - 1];
        //    double newLow = inLow[todayIdx - 1];
        //    if (isLong == 1)
        //    {
        //        ep = inHigh[todayIdx];
        //        sar = newLow;
        //    }
        //    else
        //    {
        //        ep = inLow[todayIdx];
        //        sar = newHigh;
        //    }
        //    newLow = inLow[todayIdx];
        //    newHigh = inHigh[todayIdx];
        //    while (todayIdx <= endIdx)
        //    {
        //        double prevLow = newLow;
        //        double prevHigh = newHigh;
        //        newLow = inLow[todayIdx];
        //        newHigh = inHigh[todayIdx];
        //        todayIdx++;
        //        if (isLong == 1)
        //        {
        //            if (newLow <= sar)
        //            {
        //                isLong = 0;
        //                sar = ep;
        //                if (sar < prevHigh)
        //                {
        //                    sar = prevHigh;
        //                }
        //                if (sar < newHigh)
        //                {
        //                    sar = newHigh;
        //                }
        //                outReal[outIdx] = sar;
        //                outIdx++;
        //                af = optInAcceleration;
        //                ep = newLow;
        //                sar += af * (ep - sar);
        //                if (sar < prevHigh)
        //                {
        //                    sar = prevHigh;
        //                }
        //                if (sar < newHigh)
        //                {
        //                    sar = newHigh;
        //                }
        //            }
        //            else
        //            {
        //                outReal[outIdx] = sar;
        //                outIdx++;
        //                if (newHigh > ep)
        //                {
        //                    ep = newHigh;
        //                    af += optInAcceleration;
        //                    if (af > optInMaximum)
        //                    {
        //                        af = optInMaximum;
        //                    }
        //                }
        //                sar += af * (ep - sar);
        //                if (sar > prevLow)
        //                {
        //                    sar = prevLow;
        //                }
        //                if (sar > newLow)
        //                {
        //                    sar = newLow;
        //                }
        //            }
        //        }
        //        else if (newHigh >= sar)
        //        {
        //            isLong = 1;
        //            sar = ep;
        //            if (sar > prevLow)
        //            {
        //                sar = prevLow;
        //            }
        //            if (sar > newLow)
        //            {
        //                sar = newLow;
        //            }
        //            outReal[outIdx] = sar;
        //            outIdx++;
        //            af = optInAcceleration;
        //            ep = newHigh;
        //            sar += af * (ep - sar);
        //            if (sar > prevLow)
        //            {
        //                sar = prevLow;
        //            }
        //            if (sar > newLow)
        //            {
        //                sar = newLow;
        //            }
        //        }
        //        else
        //        {
        //            outReal[outIdx] = sar;
        //            outIdx++;
        //            if (newLow < ep)
        //            {
        //                ep = newLow;
        //                af += optInAcceleration;
        //                if (af > optInMaximum)
        //                {
        //                    af = optInMaximum;
        //                }
        //            }
        //            sar += af * (ep - sar);
        //            if (sar < prevHigh)
        //            {
        //                sar = prevHigh;
        //            }
        //            if (sar < newHigh)
        //            {
        //                sar = newHigh;
        //            }
        //        }
        //    }
        //    outNBElement = outIdx;
        //    return RetCode.Success;
        //}
        //public static RetCode Sar(int startIdx, int endIdx, float[] inHigh, float[] inLow, double optInAcceleration, double optInMaximum, ref int outBegIdx, ref int outNBElement, double[] outReal)
        //{
        //    double sar;
        //    double ep;
        //    int isLong;
        //    int tempInt = 0;
        //    double[] ep_temp = new double[1];
        //    if (startIdx < 0)
        //    {
        //        return RetCode.OutOfRangeStartIndex;
        //    }
        //    if ((endIdx < 0) || (endIdx < startIdx))
        //    {
        //        return RetCode.OutOfRangeEndIndex;
        //    }
        //    if ((inHigh == null) || (inLow == null))
        //    {
        //        return RetCode.BadParam;
        //    }
        //    if (optInAcceleration == -4E+37)
        //    {
        //        optInAcceleration = 0.02;
        //    }
        //    else if ((optInAcceleration < 0.0) || (optInAcceleration > 3E+37))
        //    {
        //        return RetCode.BadParam;
        //    }
        //    if (optInMaximum == -4E+37)
        //    {
        //        optInMaximum = 0.2;
        //    }
        //    else if ((optInMaximum < 0.0) || (optInMaximum > 3E+37))
        //    {
        //        return RetCode.BadParam;
        //    }
        //    if (outReal == null)
        //    {
        //        return RetCode.BadParam;
        //    }
        //    if (startIdx < 1)
        //    {
        //        startIdx = 1;
        //    }
        //    if (startIdx > endIdx)
        //    {
        //        outBegIdx = 0;
        //        outNBElement = 0;
        //        return RetCode.Success;
        //    }
        //    double af = optInAcceleration;
        //    if (af > optInMaximum)
        //    {
        //        optInAcceleration = optInMaximum;
        //        af = optInAcceleration;
        //    }
        //    RetCode retCode = MinusDM(startIdx, startIdx, inHigh, inLow, 1, ref tempInt, ref tempInt, ep_temp);
        //    if (ep_temp[0] > 0.0)
        //    {
        //        isLong = 0;
        //    }
        //    else
        //    {
        //        isLong = 1;
        //    }
        //    if (retCode != RetCode.Success)
        //    {
        //        outBegIdx = 0;
        //        outNBElement = 0;
        //        return retCode;
        //    }
        //    outBegIdx = startIdx;
        //    int outIdx = 0;
        //    int todayIdx = startIdx;
        //    double newHigh = inHigh[todayIdx - 1];
        //    double newLow = inLow[todayIdx - 1];
        //    if (isLong == 1)
        //    {
        //        ep = inHigh[todayIdx];
        //        sar = newLow;
        //    }
        //    else
        //    {
        //        ep = inLow[todayIdx];
        //        sar = newHigh;
        //    }
        //    newLow = inLow[todayIdx];
        //    newHigh = inHigh[todayIdx];
        //    while (todayIdx <= endIdx)
        //    {
        //        double prevLow = newLow;
        //        double prevHigh = newHigh;
        //        newLow = inLow[todayIdx];
        //        newHigh = inHigh[todayIdx];
        //        todayIdx++;
        //        if (isLong == 1)
        //        {
        //            if (newLow <= sar)
        //            {
        //                isLong = 0;
        //                sar = ep;
        //                if (sar < prevHigh)
        //                {
        //                    sar = prevHigh;
        //                }
        //                if (sar < newHigh)
        //                {
        //                    sar = newHigh;
        //                }
        //                outReal[outIdx] = sar;
        //                outIdx++;
        //                af = optInAcceleration;
        //                ep = newLow;
        //                sar += af * (ep - sar);
        //                if (sar < prevHigh)
        //                {
        //                    sar = prevHigh;
        //                }
        //                if (sar < newHigh)
        //                {
        //                    sar = newHigh;
        //                }
        //            }
        //            else
        //            {
        //                outReal[outIdx] = sar;
        //                outIdx++;
        //                if (newHigh > ep)
        //                {
        //                    ep = newHigh;
        //                    af += optInAcceleration;
        //                    if (af > optInMaximum)
        //                    {
        //                        af = optInMaximum;
        //                    }
        //                }
        //                sar += af * (ep - sar);
        //                if (sar > prevLow)
        //                {
        //                    sar = prevLow;
        //                }
        //                if (sar > newLow)
        //                {
        //                    sar = newLow;
        //                }
        //            }
        //        }
        //        else if (newHigh >= sar)
        //        {
        //            isLong = 1;
        //            sar = ep;
        //            if (sar > prevLow)
        //            {
        //                sar = prevLow;
        //            }
        //            if (sar > newLow)
        //            {
        //                sar = newLow;
        //            }
        //            outReal[outIdx] = sar;
        //            outIdx++;
        //            af = optInAcceleration;
        //            ep = newHigh;
        //            sar += af * (ep - sar);
        //            if (sar > prevLow)
        //            {
        //                sar = prevLow;
        //            }
        //            if (sar > newLow)
        //            {
        //                sar = newLow;
        //            }
        //        }
        //        else
        //        {
        //            outReal[outIdx] = sar;
        //            outIdx++;
        //            if (newLow < ep)
        //            {
        //                ep = newLow;
        //                af += optInAcceleration;
        //                if (af > optInMaximum)
        //                {
        //                    af = optInMaximum;
        //                }
        //            }
        //            sar += af * (ep - sar);
        //            if (sar < prevHigh)
        //            {
        //                sar = prevHigh;
        //            }
        //            if (sar < newHigh)
        //            {
        //                sar = newHigh;
        //            }
        //        }
        //    }
        //    outNBElement = outIdx;
        //    return RetCode.Success;
        //}
        //public static int SarLookback(double optInAcceleration, double optInMaximum)
        //{
        //    if (optInAcceleration == -4E+37)
        //    {
        //        optInAcceleration = 0.02;
        //    }
        //    else if ((optInAcceleration < 0.0) || (optInAcceleration > 3E+37))
        //    {
        //        return -1;
        //    }
        //    if (optInMaximum == -4E+37)
        //    {
        //        optInMaximum = 0.2;
        //    }
        //    else if ((optInMaximum < 0.0) || (optInMaximum > 3E+37))
        //    {
        //        return -1;
        //    }
        //    return 1;
        //}


        //public static RetCode MinusDM(int startIdx, int endIdx, double[] inHigh, double[] inLow, int optInTimePeriod, ref int outBegIdx, ref int outNBElement, double[] outReal)
        //{
        //    double tempReal;
        //    int today;
        //    double diffM;
        //    double prevLow;
        //    double prevHigh;
        //    double diffP;
        //    int lookbackTotal;
        //    if (startIdx < 0)
        //    {
        //        return RetCode.OutOfRangeStartIndex;
        //    }
        //    if ((endIdx < 0) || (endIdx < startIdx))
        //    {
        //        return RetCode.OutOfRangeEndIndex;
        //    }
        //    if ((inHigh == null) || (inLow == null))
        //    {
        //        return RetCode.BadParam;
        //    }
        //    if (optInTimePeriod == -2147483648)
        //    {
        //        optInTimePeriod = 14;
        //    }
        //    else if ((optInTimePeriod < 1) || (optInTimePeriod > 0x186a0))
        //    {
        //        return RetCode.BadParam;
        //    }
        //    if (outReal == null)
        //    {
        //        return RetCode.BadParam;
        //    }
        //    if (optInTimePeriod > 1)
        //    {
        //        lookbackTotal = (optInTimePeriod + ((int)Globals.unstablePeriod[0x10])) - 1;
        //    }
        //    else
        //    {
        //        lookbackTotal = 1;
        //    }
        //    if (startIdx < lookbackTotal)
        //    {
        //        startIdx = lookbackTotal;
        //    }
        //    if (startIdx > endIdx)
        //    {
        //        outBegIdx = 0;
        //        outNBElement = 0;
        //        return RetCode.Success;
        //    }
        //    int outIdx = 0;
        //    if (optInTimePeriod <= 1)
        //    {
        //        outBegIdx = startIdx;
        //        today = startIdx - 1;
        //        prevHigh = inHigh[today];
        //        prevLow = inLow[today];
        //        while (today < endIdx)
        //        {
        //            today++;
        //            tempReal = inHigh[today];
        //            diffP = tempReal - prevHigh;
        //            prevHigh = tempReal;
        //            tempReal = inLow[today];
        //            diffM = prevLow - tempReal;
        //            prevLow = tempReal;
        //            if ((diffM > 0.0) && (diffP < diffM))
        //            {
        //                outReal[outIdx] = diffM;
        //                outIdx++;
        //            }
        //            else
        //            {
        //                outReal[outIdx] = 0.0;
        //                outIdx++;
        //            }
        //        }
        //        outNBElement = outIdx;
        //        return RetCode.Success;
        //    }
        //    outBegIdx = startIdx;
        //    double prevMinusDM = 0.0;
        //    today = startIdx - lookbackTotal;
        //    prevHigh = inHigh[today];
        //    prevLow = inLow[today];
        //    int i = optInTimePeriod - 1;
        //Label_0138:
        //    i--;
        //    if (i > 0)
        //    {
        //        today++;
        //        tempReal = inHigh[today];
        //        diffP = tempReal - prevHigh;
        //        prevHigh = tempReal;
        //        tempReal = inLow[today];
        //        diffM = prevLow - tempReal;
        //        prevLow = tempReal;
        //        if ((diffM > 0.0) && (diffP < diffM))
        //        {
        //            prevMinusDM += diffM;
        //        }
        //        goto Label_0138;
        //    }
        //    i = (int)Globals.unstablePeriod[0x10];
        //Label_0186:
        //    i--;
        //    if (i != 0)
        //    {
        //        today++;
        //        tempReal = inHigh[today];
        //        diffP = tempReal - prevHigh;
        //        prevHigh = tempReal;
        //        tempReal = inLow[today];
        //        diffM = prevLow - tempReal;
        //        prevLow = tempReal;
        //        if ((diffM > 0.0) && (diffP < diffM))
        //        {
        //            prevMinusDM = (prevMinusDM - (prevMinusDM / ((double)optInTimePeriod))) + diffM;
        //        }
        //        else
        //        {
        //            prevMinusDM -= prevMinusDM / ((double)optInTimePeriod);
        //        }
        //        goto Label_0186;
        //    }
        //    outReal[0] = prevMinusDM;
        //    outIdx = 1;
        //    while (true)
        //    {
        //        if (today >= endIdx)
        //        {
        //            break;
        //        }
        //        today++;
        //        tempReal = inHigh[today];
        //        diffP = tempReal - prevHigh;
        //        prevHigh = tempReal;
        //        tempReal = inLow[today];
        //        diffM = prevLow - tempReal;
        //        prevLow = tempReal;
        //        if ((diffM > 0.0) && (diffP < diffM))
        //        {
        //            prevMinusDM = (prevMinusDM - (prevMinusDM / ((double)optInTimePeriod))) + diffM;
        //        }
        //        else
        //        {
        //            prevMinusDM -= prevMinusDM / ((double)optInTimePeriod);
        //        }
        //        outReal[outIdx] = prevMinusDM;
        //        outIdx++;
        //    }
        //    outNBElement = outIdx;
        //    return RetCode.Success;
        //}
        //public static RetCode MinusDM(int startIdx, int endIdx, float[] inHigh, float[] inLow, int optInTimePeriod, ref int outBegIdx, ref int outNBElement, double[] outReal)
        //{
        //    double tempReal;
        //    int today;
        //    double diffM;
        //    double prevLow;
        //    double prevHigh;
        //    double diffP;
        //    int lookbackTotal;
        //    if (startIdx < 0)
        //    {
        //        return RetCode.OutOfRangeStartIndex;
        //    }
        //    if ((endIdx < 0) || (endIdx < startIdx))
        //    {
        //        return RetCode.OutOfRangeEndIndex;
        //    }
        //    if ((inHigh == null) || (inLow == null))
        //    {
        //        return RetCode.BadParam;
        //    }
        //    if (optInTimePeriod == -2147483648)
        //    {
        //        optInTimePeriod = 14;
        //    }
        //    else if ((optInTimePeriod < 1) || (optInTimePeriod > 0x186a0))
        //    {
        //        return RetCode.BadParam;
        //    }
        //    if (outReal == null)
        //    {
        //        return RetCode.BadParam;
        //    }
        //    if (optInTimePeriod > 1)
        //    {
        //        lookbackTotal = (optInTimePeriod + ((int)Globals.unstablePeriod[0x10])) - 1;
        //    }
        //    else
        //    {
        //        lookbackTotal = 1;
        //    }
        //    if (startIdx < lookbackTotal)
        //    {
        //        startIdx = lookbackTotal;
        //    }
        //    if (startIdx > endIdx)
        //    {
        //        outBegIdx = 0;
        //        outNBElement = 0;
        //        return RetCode.Success;
        //    }
        //    int outIdx = 0;
        //    if (optInTimePeriod <= 1)
        //    {
        //        outBegIdx = startIdx;
        //        today = startIdx - 1;
        //        prevHigh = inHigh[today];
        //        prevLow = inLow[today];
        //        while (today < endIdx)
        //        {
        //            today++;
        //            tempReal = inHigh[today];
        //            diffP = tempReal - prevHigh;
        //            prevHigh = tempReal;
        //            tempReal = inLow[today];
        //            diffM = prevLow - tempReal;
        //            prevLow = tempReal;
        //            if ((diffM > 0.0) && (diffP < diffM))
        //            {
        //                outReal[outIdx] = diffM;
        //                outIdx++;
        //            }
        //            else
        //            {
        //                outReal[outIdx] = 0.0;
        //                outIdx++;
        //            }
        //        }
        //        outNBElement = outIdx;
        //        return RetCode.Success;
        //    }
        //    outBegIdx = startIdx;
        //    double prevMinusDM = 0.0;
        //    today = startIdx - lookbackTotal;
        //    prevHigh = inHigh[today];
        //    prevLow = inLow[today];
        //    int i = optInTimePeriod - 1;
        //Label_0141:
        //    i--;
        //    if (i > 0)
        //    {
        //        today++;
        //        tempReal = inHigh[today];
        //        diffP = tempReal - prevHigh;
        //        prevHigh = tempReal;
        //        tempReal = inLow[today];
        //        diffM = prevLow - tempReal;
        //        prevLow = tempReal;
        //        if ((diffM > 0.0) && (diffP < diffM))
        //        {
        //            prevMinusDM += diffM;
        //        }
        //        goto Label_0141;
        //    }
        //    i = (int)Globals.unstablePeriod[0x10];
        //Label_0191:
        //    i--;
        //    if (i != 0)
        //    {
        //        today++;
        //        tempReal = inHigh[today];
        //        diffP = tempReal - prevHigh;
        //        prevHigh = tempReal;
        //        tempReal = inLow[today];
        //        diffM = prevLow - tempReal;
        //        prevLow = tempReal;
        //        if ((diffM > 0.0) && (diffP < diffM))
        //        {
        //            prevMinusDM = (prevMinusDM - (prevMinusDM / ((double)optInTimePeriod))) + diffM;
        //        }
        //        else
        //        {
        //            prevMinusDM -= prevMinusDM / ((double)optInTimePeriod);
        //        }
        //        goto Label_0191;
        //    }
        //    outReal[0] = prevMinusDM;
        //    outIdx = 1;
        //    while (true)
        //    {
        //        if (today >= endIdx)
        //        {
        //            break;
        //        }
        //        today++;
        //        tempReal = inHigh[today];
        //        diffP = tempReal - prevHigh;
        //        prevHigh = tempReal;
        //        tempReal = inLow[today];
        //        diffM = prevLow - tempReal;
        //        prevLow = tempReal;
        //        if ((diffM > 0.0) && (diffP < diffM))
        //        {
        //            prevMinusDM = (prevMinusDM - (prevMinusDM / ((double)optInTimePeriod))) + diffM;
        //        }
        //        else
        //        {
        //            prevMinusDM -= prevMinusDM / ((double)optInTimePeriod);
        //        }
        //        outReal[outIdx] = prevMinusDM;
        //        outIdx++;
        //    }
        //    outNBElement = outIdx;
        //    return RetCode.Success;
        //}
        //public static int MinusDMLookback(int optInTimePeriod)
        //{
        //    if (optInTimePeriod == -2147483648)
        //    {
        //        optInTimePeriod = 14;
        //    }
        //    else if ((optInTimePeriod < 1) || (optInTimePeriod > 0x186a0))
        //    {
        //        return -1;
        //    }
        //    if (optInTimePeriod > 1)
        //    {
        //        return ((optInTimePeriod + ((int)Globals.unstablePeriod[0x10])) - 1);
        //    }
        //    return 1;
        //}
    }
}
